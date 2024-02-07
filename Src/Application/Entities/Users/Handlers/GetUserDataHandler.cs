using Application.Entities.Users.Commands;
using Application.Entities.Users.Queries;
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
        private readonly IMapper _mapper;

        public GetUserDataHandler(UserManager<User>  userManager,IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle( GetUserData request, CancellationToken cancellationToken )
        {
            if (request.Email is not null)
            {
              var user=  await _userManager.FindByEmailAsync(request.Email);
              return _mapper.Map<UserDto>(user);
            }
            if (request.Username is not null)
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                return _mapper.Map<UserDto>(user);
            }
            if ( request.Id.ToString() is not null)
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());
                return _mapper.Map<UserDto>(user);
            }
            return new();
         
        }
    }
}
