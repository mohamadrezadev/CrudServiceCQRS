using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Users
{
    public class Role :IdentityRole<Guid>, IEntity
    {
        public Role()
        {
            
        }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }



    }
}
