using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistances.Common
{
	public static class SeedProductsInDb
	{
		public static void SeedProducts( ModelBuilder modelBuilder )
		{
			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id= 1,
					Name = "Apple iPhone 13",
					Description = "One small reduction of the notch, one giant leap for the iPhone! That's the best description for the most minor iPhone upgrade yet - the Apple iPhone 13.",
					imageURl= "https://www.technolife.ir/image/small_product-TLP-4993_e62cc295-8d95-469e-bfa1-7bda32e2ee7b.png"	,
					Price = 30_000_000
				},
				new Product
				{
					Id= 2,
					 Name= "شیائومی مدل 13T Pro 5G",
					 Description = "گوشی موبایل شیائومی مدل 13T Pro 5G ظرفیت 512 گیگابایت رم 12 گیگابایت" ,
					 imageURl ="https://www.technolife.ir/image/small_product-TLP-28793_c8143e09-d41c-45a3-89cf-67cc8a8e8ce2.png" ,
					 Price= 27_700_000

				} , new Product
				{
					Id= 3,
					Name = "موبايل سامسونگ مدل Galaxy S24 Plus 5G ",
					Description = "گوشی موبايل سامسونگ مدل Galaxy S24 Plus 5G ظرفیت 256 گیگابایت رم 12 گیگابایت",
					imageURl = "https://www.technolife.ir/image/small_product-TLP-28800_c90207e3-ccdc-4630-900a-337299189f08.png",
					Price = 20_900_000

				}
			);
		}
	}
}
