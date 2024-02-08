using Application.Entities.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Commands
{
    public class RegisterUser:IRequest<ResultRegister>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Rolename { get; set; }
    }
    public class ResultRegister
    {
        public ResultRegister( UserDto userDto )
        {
            this.userDto = userDto;
        }
        public ResultRegister( IEnumerable<IdentityError> Erorrs )
        {
            this.Erors = Erorrs;
        }
        public ResultRegister(UserDto userDto, IEnumerable<IdentityError> Erorrs )
        {
                 this.userDto = userDto;
                this.Erors = Erorrs;
        }
        public UserDto userDto { get; set; }
        public IEnumerable<IdentityError> Erors { get; set; }
    }
}
