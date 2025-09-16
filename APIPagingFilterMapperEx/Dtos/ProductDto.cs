namespace APIPagingFilterMapperEx.Dtos
{
	
	//to create new product project
	public class ProductDto
	{
		public string ProductName { get; set; }
		public string MfgName { get; set; }
		public decimal Price { get; set; }
		public Int64 CategoryID { get; set; }
	}
}
