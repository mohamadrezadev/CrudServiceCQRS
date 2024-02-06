using Application.Interface.Common;
using Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> AddRoleToUserAsync(User user, Role userRole);
    }
}
