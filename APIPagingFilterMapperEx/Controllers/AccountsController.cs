using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIPagingFilterMapperEx.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		IUser userrepo;
		public AccountsController(IUser userrepo)
		{ 
		  this.userrepo= userrepo;
		}
		[HttpPost("signup")]
		public async Task<IActionResult> SignUp(RegistrationDto rec)
		{ 
		  var res=await this.userrepo.Register(rec);
			if (res.Succeeded)
			{
				return Ok("Registration Successfull!");
			}
			else
			{
				List<string> errors = new List<string>();
				foreach (var error in res.Errors)
				{
					errors.Add(error.Description);
				}
				return BadRequest(errors);
			}
		}
	}
}
