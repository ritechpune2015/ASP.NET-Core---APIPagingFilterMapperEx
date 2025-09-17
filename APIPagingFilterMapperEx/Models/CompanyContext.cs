using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace APIPagingFilterMapperEx.Models
{
	//public class CompanyContext:DbContext
	public class CompanyContext :IdentityDbContext<AppUser>
	{
		public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder); //must

			modelBuilder.Entity<Category>().HasData(
				 new Category()
				 {
					 CategoryID = 1,
					 CategoryName = "Computer"
				 },
				 				 new Category()
								  {
									  CategoryID = 2,
									  CategoryName = "Home Appliances"
								  }
				);

			modelBuilder.Entity<Product>().HasData(
				 new Product()
				 {
					 ProductID = 1,
					 ProductName = "Mouse",
					 MfgName = "Intex",
					 Price = 450,
					 CategoryID=1,
				 },
				 new Product()
				 {
					 ProductID = 2,
					 ProductName = "Keyboard",
					 MfgName="Logitech",
					 Price=950,
					 CategoryID=1
				 },
				 new Product()
				 {
					 ProductID = 3,
					 ProductName = "Washing Machine",
					 MfgName = "Bosh",
					 Price = 55550,
					 CategoryID = 2
				 },
				  new Product()
				  {
					  ProductID = 4,
					  ProductName = "LED TV",
					  MfgName = "LG",
					  Price = 85550,
					  CategoryID = 2
				  },
				  new Product()
				  {
					  ProductID = 5,
					  ProductName = "Dish Washer",
					  MfgName = "Bosh",
					  Price = 45550,
					  CategoryID = 2
				  },
				  new Product()
				  {
					  ProductID = 6,
					  ProductName = "Web CAM",
					  MfgName = "Lenovo",
					  Price = 15550,
					  CategoryID =1
				  },
				  new Product()
				  {
					  ProductID = 7,
					  ProductName = "Hard Disk",
					  MfgName = "Segate",
					  Price = 13550,
					  CategoryID = 1
				  }
				);
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
