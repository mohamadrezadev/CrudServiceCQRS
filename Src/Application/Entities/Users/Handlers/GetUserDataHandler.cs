using Application.Entities.Dtos;
using Application.Entities.Users.Queries;
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
    public class GetUserDataHandler : IRequestHandler<GetUserData, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUserDataHandler( IMapper mapper ,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle( GetUserData request, CancellationToken cancellationToken )
        {
            if (request.Email is not null)
            {
              var user=  await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
              return _mapper.Map<UserDto>(user);
            }
            if (request.Username is not null)
            {
                var user = await _unitOfWork.UserManager.FindByNameAsync(request.Username);
                return _mapper.Map<UserDto>(user);
            }
            if ( request.Id.ToString() is not null)
            {
                var user = await _unitOfWork.UserManager.FindByIdAsync(request.Id.ToString());
                return _mapper.Map<UserDto>(user);
            }
            return new();
         
        }
    }
}
