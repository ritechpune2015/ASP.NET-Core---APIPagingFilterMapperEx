using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Models;
using AutoMapper;

namespace APIPagingFilterMapperEx.Configuration
{
	public class AutomapperProfile:Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<Product, ProductDisplayDto>().ForMember(p=>p.CategoryName,q=>q.MapFrom(t=>t.Category.CategoryName)).ReverseMap();

			CreateMap<Product, ProductUpdateDto>().ReverseMap();
		}
	}
}
