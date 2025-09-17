using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIPagingFilterMapperEx.Repositories
{
	public class UserRepo : IUser
	{
		UserManager<AppUser> _userManager;
		IMapper _mapper;
		public UserRepo(UserManager<AppUser> userManager,IMapper mapper)
		{ 
		  this._userManager = userManager;
	      this._mapper = mapper;
		}
		public async Task<IdentityResult> Register(RegistrationDto rec)
		{

			var urec = this._mapper.Map<AppUser>(rec);
			urec.UserName = rec.EmailID;
			var result =await this._userManager.CreateAsync(urec,rec.Password);
			return result;
		}
	}
}
