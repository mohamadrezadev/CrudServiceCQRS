using Domain.Common;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Orders
{
    public class Order:IEntity
    {

        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double TootalPrice { get; set; }
        public List<OrderDetail> orderDetails { get; set; } = new List<OrderDetail>();
		public Guid UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

    }
}
