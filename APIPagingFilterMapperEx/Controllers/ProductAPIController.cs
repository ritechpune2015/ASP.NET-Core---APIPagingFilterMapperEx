using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Helpers;
using APIPagingFilterMapperEx.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIPagingFilterMapperEx.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //every controller 
	public class ProductAPIController : ControllerBase
	{
		IProductRepo repo;
		public ProductAPIController(IProductRepo repo)
		{ 
		 this.repo = repo;
		}

		/// <summary>
		/// Retrive Product Info with filter, sorting and paging
		/// </summary>
		/// <param name="query"></param>
		/// <returns> List of Products</returns>

		[HttpGet]
		public async Task<IActionResult> Index([FromQuery]QueryObject query)
		{
			var res =await this.repo.GetAll(query);
			if (res == null)
				return NotFound();
			return Ok(res);
		}

		/// <summary>
		/// Create New Product
		/// </summary>
		/// <param name="rec"></param>
		/// <returns></returns>

		[HttpPost]
		public async Task<IActionResult> Create(ProductDto rec)
		{
			if(rec==null)
				return BadRequest();

			await this.repo.Create(rec);
			return Ok(rec); 
		}


		/// <summary>
		/// Modify Existing Product
		/// </summary>
		/// <param name="rec"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> Update(ProductUpdateDto rec)
		{
			if (rec == null)
				return BadRequest();

			await this.repo.Update(rec);
			return Ok(rec);
		}


		/// <summary>
		/// Delete Existing Product
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>

		[HttpDelete]
		public async Task<IActionResult> Delete(Int64 id)
		{
			if (id == 0)
				return BadRequest();

			await this.repo.Delete(id);
			return Ok("Deleted");
		}
	}
}
