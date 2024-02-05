using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Products.Queries
{
    public class GetProductByid :IRequest<Product>
    {
        public int Id { get; set; }
    }
}
