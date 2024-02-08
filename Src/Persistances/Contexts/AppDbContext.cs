using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistances.Common;
using System.Reflection.Emit;

namespace Persistances.Contexts
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating( ModelBuilder builder )
		{
           


			builder.Entity<User>()
				  .HasMany(u => u.Orders)
				  .WithOne(o => o.User)
				  .HasForeignKey(o => o.UserId)
				  .OnDelete(DeleteBehavior.Cascade)
				  .IsRequired();

			builder.Entity<Order>()
			.HasOne(o => o.User)
			.WithMany(u => u.Orders)
			.HasPrincipalKey(u => u.Id)
			.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Order>()
				.HasMany(od=>od.orderDetails)
				.WithOne(o => o.Order)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Entity<OrderDetail>()
				.HasOne(o=>o.Order)
				.WithMany(od=>od.orderDetails)
				.OnDelete(DeleteBehavior.Restrict);



			builder.Entity<Product>()
				.HasMany(p => p.OrderDetails)
				.WithOne(od => od.Product)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					Name = "Apple iPhone 13",
					Description = "One small reduction of the notch, one giant leap for the iPhone! That's the best description for the most minor iPhone upgrade yet - the Apple iPhone 13.",
					imageURl = "https://www.technolife.ir/image/small_product-TLP-4993_e62cc295-8d95-469e-bfa1-7bda32e2ee7b.png",
					Price = 30_000_000
				},
				new Product
				{
					Id = 2,
					Name = "شیائومی مدل 13T Pro 5G",
					Description = "گوشی موبایل شیائومی مدل 13T Pro 5G ظرفیت 512 گیگابایت رم 12 گیگابایت",
					imageURl = "https://www.technolife.ir/image/small_product-TLP-28793_c8143e09-d41c-45a3-89cf-67cc8a8e8ce2.png",
					Price = 27_700_000

				}, new Product
				{
					Id = 3,
					Name = "موبايل سامسونگ مدل Galaxy S24 Plus 5G ",
					Description = "گوشی موبايل سامسونگ مدل Galaxy S24 Plus 5G ظرفیت 256 گیگابایت رم 12 گیگابایت",
					imageURl = "https://www.technolife.ir/image/small_product-TLP-28800_c90207e3-ccdc-4630-900a-337299189f08.png",
					Price = 20_900_000

				}
			);
		
		   base.OnModelCreating(builder);
          

        }
	}
}
