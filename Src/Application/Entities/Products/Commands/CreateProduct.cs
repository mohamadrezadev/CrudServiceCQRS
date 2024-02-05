using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Products.Commands
{
    public class CreateProduct:IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
    public class UpdateProduct:IRequest<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
    public class DeleteProduct : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
