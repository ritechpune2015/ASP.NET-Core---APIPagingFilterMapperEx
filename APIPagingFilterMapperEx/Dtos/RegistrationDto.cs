using System.ComponentModel.DataAnnotations;

namespace APIPagingFilterMapperEx.Dtos
{
	public class RegistrationDto
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string MobileNo { get; set; }
		[Required]
		public string Password { get; set; }

		[Required]
		public string EmailID { get; set; }

	}
}
