using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Models;
using APIPagingFilterMapperEx.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIPagingFilterMapperEx.Repositories
{
	public class UserRepo : IUser
	{
		UserManager<AppUser> _userManager;
		SignInManager<AppUser> _signInManager;
		IMapper _mapper;
		ITokenService tokensvr;
		public UserRepo(UserManager<AppUser> userManager,IMapper mapper,SignInManager<AppUser> signinmanager,ITokenService tsvr)
		{ 
		  this._userManager = userManager;
	      this._mapper = mapper;
	      this._signInManager = signinmanager;
		  this.tokensvr= tsvr;
		}

		public async Task<LoginResultDto> Login(LoginDto rec)
		{
			LoginResultDto result = new LoginResultDto();
			var user = await this._userManager.Users.FirstOrDefaultAsync(p => p.UserName == rec.EmailID);
			if (user == null)
			{
				result.IsSuccess = false;
				result.Message = "Invalid Email ID!";
				return result;
			}

			var res=await this._signInManager.CheckPasswordSignInAsync(user,rec.Password,false);
			if (res.Succeeded)
			{
				result.Name = user.FirstName;
				result.IsSuccess = true;
				result.Token = this.tokensvr.GenenerateToken(user);
				return result;
			}
			else
			{
				result.IsSuccess = false;
				result.Message = "Invalid Email ID or Password!";
				return result;
			}

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
