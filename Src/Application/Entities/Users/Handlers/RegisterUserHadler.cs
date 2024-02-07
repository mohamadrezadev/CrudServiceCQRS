using Application.Entities.Users.Commands;
using AutoMapper;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Handlers
{
    public class RegisterUserHadler : IRequestHandler<RegisterUser, ResultRegister>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RegisterUserHadler(UserManager<User> userManager,RoleManager<Role> roleManager,IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<ResultRegister> Handle( RegisterUser request, CancellationToken cancellationToken )
        {
            var newuser=_mapper.Map<User>( request);
            var result=await _userManager.CreateAsync(newuser,request.Password);
            if (result.Succeeded)
            {
                var exsistRole=   await CreateUserRoleOrFindRole(request.Rolename);
                if (exsistRole)
                {
                   var Res= await _userManager.AddToRoleAsync(newuser, request.Rolename);
                   if (Res.Succeeded)
                   {
                        var userdata = _mapper.Map<UserDto>(newuser);
                        return new(userdata);
                   }
                }
                
            }  
            return new(result.Errors);
            
        }
        private async Task<bool> CreateUserRoleOrFindRole( string rolename )
        {

           var ExistRole= await _roleManager.FindByNameAsync( rolename );
            if (ExistRole == null)
            {
                var result = await _roleManager.CreateAsync(new Role()
                {
                    Name = rolename,
                    Description = $"this role for {rolename} ",
                    RoleName = rolename,
                    NormalizedName = rolename
                });
                if (result.Succeeded)
                {
                    return true;
                }
            }
            return false;





        }
    }
}
