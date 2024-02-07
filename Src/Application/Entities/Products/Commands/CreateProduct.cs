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
        public string imageURl { get; set; }
        public int Price { get; set; }
    }
}
