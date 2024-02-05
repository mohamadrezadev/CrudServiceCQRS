using Domain.Entities.Orders;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Orders.Commands
{
    public class CreateOrder : IRequest<int>
    {
        public string City { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

    }
}
