﻿using Application.Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Queries
{
    public class GetUserData:IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
    public class GetListUsers : IRequest<List<UserDto>>
    {
        public GetListUsers()
        {
            
        }
    }
}
