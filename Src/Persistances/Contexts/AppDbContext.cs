using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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

			builder.Entity<OrderDetail>()
				.HasOne(od => od.Product)
				.WithOne(p => p.OrderDetail)
				.HasForeignKey<OrderDetail>(od => od.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Product>()
				.HasOne(p => p.OrderDetail)
				.WithOne(od => od.Product)
				.HasForeignKey<OrderDetail>(od => od.ProductId)
				.OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(builder);

		}
	}
}
