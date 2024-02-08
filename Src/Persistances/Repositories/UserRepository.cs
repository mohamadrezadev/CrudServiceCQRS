using Application.Interface;
using Application.Interface.Common;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Persistances.Common;
using Persistances.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistances.Users
{
    public class UserRepository : Repository<User>  ,IUserRepository
    {
        public UserRepository( AppDbContext dbContext ) : base(dbContext)
        {
        }

        public Task<bool> AddRoleToUserAsync( User user, Role userRole )
        {
            throw new NotImplementedException();
        }
    }
}
