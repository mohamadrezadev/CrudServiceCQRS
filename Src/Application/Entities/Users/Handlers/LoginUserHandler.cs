using Application.Entities.Users.Commands;
using Application.Interface.Common;
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
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LoginUserHandler( IUnitOfWork unitOfWork,   IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<loginDto> Handle( LoginUser request, CancellationToken cancellationToken )
        {
            var finduser= await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
            if ( finduser != null )
            {
				var roles = await _unitOfWork.UserManager.GetRolesAsync(finduser);
				var Result = await _unitOfWork.SignInManager.PasswordSignInAsync(finduser, request.Password, true, false);
				return new loginDto(Result, roles.ToList());
			}
            return new() ;
           
           
        }
    }
}
