using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Helpers;
using APIPagingFilterMapperEx.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIPagingFilterMapperEx.Repositories
{
	public class ProductRepo : IProductRepo
	{
		CompanyContext cc;
		IMapper mapper;
		public ProductRepo(CompanyContext cc,IMapper map)
		{
			this.cc = cc;
			this.mapper = map;
		}

		public async Task<ProductDto> Create(ProductDto rec)
		{
			var prec = this.mapper.Map<Product>(rec);
			await this.cc.Products.AddAsync(prec);
			await this.cc.SaveChangesAsync();
			return rec;
		}

		public async Task Delete(long id)
		{
			var prod = await this.cc.Products.FindAsync(id);
			this.cc.Products.Remove(prod);
			await this.cc.SaveChangesAsync();
		}

		public async Task<List<ProductDisplayDto>> GetAll(QueryObject query)
		{
			//IQueryable = query result

			var products =this.cc.Products.AsQueryable();

			if (query.MinPrice != null)
			{
				products = products.Where(p => p.Price > query.MinPrice);
			}

			if(query.MaxPrice != null) 
			{ 
		       products =products.Where(p=>p.Price < query.MaxPrice);		
			}

		    if (!string.IsNullOrWhiteSpace(query.SortyBy)) //name
			{
					if (query.SortyBy.Equals("ProductName", StringComparison.OrdinalIgnoreCase))
					{
						products = query.isDescending ?
							 products.OrderByDescending(p => p.ProductName) : products.OrderBy(p => p.ProductName);
					}
					else if (query.SortyBy.Equals("Price",StringComparison.OrdinalIgnoreCase))
					{
					products = query.isDescending ?
						  products.OrderByDescending(p => p.Price) :
						  products.OrderBy(p => p.Price);
					}
					
			}

				int skipnumber = (query.PageNo - 1) * query.PageSize;
			var res= await products.Skip(skipnumber).Take(query.PageSize).ToListAsync();

				return this.mapper.Map<List<ProductDisplayDto>>(res);
		 }

		public async Task<ProductDisplayDto> GetById(long id)
		{
			return this.mapper.Map<ProductDisplayDto>(await this.cc.Products.FindAsync(id));
		}

		public async Task<ProductUpdateDto> Update(ProductUpdateDto rec)
		{
			var prodrec = this.mapper.Map<Product>(rec);
			this.cc.Entry(rec).State = EntityState.Modified;
			await this.cc.SaveChangesAsync();
			return rec;
		}
	}
}
