using APIPagingFilterMapperEx.Dtos;
using Microsoft.AspNetCore.Identity;

namespace APIPagingFilterMapperEx.Repositories
{
	public interface IUser
	{
		Task<IdentityResult> Register(RegistrationDto rec);
	}
}
