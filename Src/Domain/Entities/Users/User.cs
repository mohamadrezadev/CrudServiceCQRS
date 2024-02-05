using Domain.Common;
using Domain.Entities.Orders;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Entities.Users
{
    public class User : IdentityUser<Guid>, IEntity
    {
    
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }


        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
            this.Orders = new List<Order>();
        }

    }
}
