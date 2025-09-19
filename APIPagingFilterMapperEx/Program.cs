using APIPagingFilterMapperEx.Configuration;
using APIPagingFilterMapperEx.Models;
using APIPagingFilterMapperEx.Repositories;
using APIPagingFilterMapperEx.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
	 opt => {
		 opt.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo(){Title="Demo API",Version="v1" });

		 opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
		 {
			 In = ParameterLocation.Header,
			 Description = "Please enter a valid token",
			 Name = "Authorization",
			 Type = SecuritySchemeType.Http,
			 BearerFormat = "JWT",
			 Scheme = "Bearer"
		 });
		 opt.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id="Bearer"
				}
			},
			new string[]{}
		}
	});


	 }
	);

builder.Services.AddControllers();
var scon = builder.Configuration.GetConnectionString("scon");

 
builder.Services.AddDbContext<CompanyContext>(opt=>opt.UseLazyLoadingProxies().UseSqlServer(scon));

builder.Services.AddIdentity<AppUser, IdentityRole>(
	).AddEntityFrameworkStores<CompanyContext>();

var issuer = builder.Configuration["JWT:issuer"];
var audience = builder.Configuration["JWT:audience"];
var key =System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]);
var skey = new SymmetricSecurityKey(key);

builder.Services.AddAuthentication(
	 opt => {
		 opt.DefaultScheme =
		 opt.DefaultForbidScheme =
		 opt.DefaultAuthenticateScheme =
		 opt.DefaultChallengeScheme =
		 opt.DefaultSignInScheme =
		opt.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
	  }
	).AddJwtBearer(opt => {
		opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
		{
			 ValidateIssuer=true,
			 ValidateAudience=true,
			 ValidateIssuerSigningKey=true,
			 ValidateLifetime=true,
			 ValidIssuer=issuer,
			 ValidAudience=audience,
			 IssuerSigningKey=skey
		};
	});
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddScoped<IProductRepo,ProductRepo>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
