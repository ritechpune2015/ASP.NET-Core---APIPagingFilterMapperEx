using APIPagingFilterMapperEx.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace APIPagingFilterMapperEx.Services
{
	public class TokenService : ITokenService
	{
		IConfiguration _config;
		public TokenService(IConfiguration configuration) { 
		 this._config=configuration;
		}
		public string GenenerateToken(AppUser rec)
		{
			//configure claims
			var claims = new List<Claim>() {
			  new Claim(JwtRegisteredClaimNames.Name,rec.FirstName),
			  new Claim(JwtRegisteredClaimNames.Email,rec.UserName),
			};

			var key = System.Text.Encoding.UTF8.GetBytes(this._config["JWT:key"]);
			var skey = new SymmetricSecurityKey(key);

			var creds = new SigningCredentials(skey, SecurityAlgorithms.HmacSha512);

			var issuer = this._config["JWT:issuer"];
			var audience = this._config["JWT:audience"];

			var token = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: claims,
				expires:DateTime.Now.AddMinutes(20),
				signingCredentials: creds
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
