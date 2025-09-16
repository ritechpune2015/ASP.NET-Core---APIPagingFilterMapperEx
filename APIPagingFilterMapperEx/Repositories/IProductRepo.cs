using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Helpers;
using APIPagingFilterMapperEx.Models;

namespace APIPagingFilterMapperEx.Repositories
{
	public interface IProductRepo
	{
		Task<List<ProductDisplayDto>> GetAll(QueryObject query);
		Task<ProductDisplayDto> GetById(Int64 id);
		Task<ProductDto> Create(ProductDto rec);
		Task<ProductUpdateDto> Update(ProductUpdateDto rec);
		Task Delete(Int64 id);
	}
}
