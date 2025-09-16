using System.Security.Principal;

namespace APIPagingFilterMapperEx.Helpers
{
	public class QueryObject
	{
		public decimal ? MinPrice { get; set; }
		public decimal ? MaxPrice { get; set; }
		public int PageSize { get; set; } = 5;
		public int PageNo { get; set; } = 1;
		public string SortyBy { get; set; }
		public bool isDescending { get; set; }
	}
}
