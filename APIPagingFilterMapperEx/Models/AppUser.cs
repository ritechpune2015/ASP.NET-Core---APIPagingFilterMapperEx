using Microsoft.AspNetCore.Identity;

namespace APIPagingFilterMapperEx.Models
{
	public class AppUser:IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string MobileNo { get; set; }
	}
}
