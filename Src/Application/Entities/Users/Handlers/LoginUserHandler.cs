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
    public class LoginUserHandler : IRequestHandler<LoginUser, loginDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public LoginUserHandler( UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<loginDto> Handle( LoginUser request, CancellationToken cancellationToken )
        {
            var finduser= await _userManager.FindByEmailAsync(request.Email);
            if ( finduser != null )
            {
				var roles = await _userManager.GetRolesAsync(finduser);
				var Result = await _signInManager.PasswordSignInAsync(finduser, request.Password, true, false);
				return new loginDto(Result, roles.ToList());
			}
            return new() ;
           
           
        }
    }
}
