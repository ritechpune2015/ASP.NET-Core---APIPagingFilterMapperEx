using APIPagingFilterMapperEx.Dtos;
using APIPagingFilterMapperEx.Helpers;
using APIPagingFilterMapperEx.Models;
using APIPagingFilterMapperEx.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIPagingFilterMapperEx.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductAPIController : ControllerBase
	{
		IProductRepo repo;
		public ProductAPIController(IProductRepo repo)
		{ 
		 this.repo = repo;
		}
		[HttpGet]
		public async Task<IActionResult> Index([FromQuery]QueryObject query)
		{
			var res =await this.repo.GetAll(query);
			if (res == null)
				return NotFound();
			return Ok(res);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductDto rec)
		{
			if(rec==null)
				return BadRequest();

			await this.repo.Create(rec);
			return Ok(rec); 
		}

		[HttpPut]
		public async Task<IActionResult> Update(ProductUpdateDto rec)
		{
			if (rec == null)
				return BadRequest();

			await this.repo.Update(rec);
			return Ok(rec);
		}

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
