using Application.Interface;
using Application.Interface.Common;
using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Persistances.Contexts;
using Persistances.Repositories;
using Persistances.Users;


namespace Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        

        public IOrderRepository OrderRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IUserRepository UserRepository { get; }

        public UserManager<User> UserManager { get; }
        public  RoleManager<Role> RoleManager { get; }
        public SignInManager<User> SignInManager { get; }
        public UnitOfWork( AppDbContext dbContext ,UserManager<User> userManager,RoleManager<Role> roleManager,SignInManager<User> signInManager)
        {
            ProductRepository = new ProductRepository(dbContext);
            OrderRepository = new OrderRepository(dbContext);
            UserRepository=new UserRepository(dbContext);
            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;
        }

        public  void Dispose( )
        {



        }
        public async Task SaveAsync(CancellationToken cancellationToken )
        {
            await _context.SaveChangesAsync();
        }
    }
}
