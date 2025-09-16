using System.Security.Principal;

namespace APIPagingFilterMapperEx.Dtos
{
	
	//to create new product project
	public class ProductUpdateDto:ProductDto
	{
		public Int64 ProductID { get; set; }
	}
}
