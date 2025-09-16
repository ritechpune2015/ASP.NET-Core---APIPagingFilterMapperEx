using APIPagingFilterMapperEx.Configuration;
using APIPagingFilterMapperEx.Models;
using APIPagingFilterMapperEx.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var scon = builder.Configuration.GetConnectionString("scon");

builder.Services.AddDbContext<CompanyContext>(opt=>opt.UseLazyLoadingProxies().UseSqlServer(scon));

builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddScoped<IProductRepo,ProductRepo>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();
