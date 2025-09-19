using APIPagingFilterMapperEx.Models;

namespace APIPagingFilterMapperEx.Services
{
	public interface ITokenService
	{
		string GenenerateToken(AppUser rec);
	}
}
