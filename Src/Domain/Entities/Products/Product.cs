using Domain.Common;
using Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Products
{
    public class Product  :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string imageURl { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
