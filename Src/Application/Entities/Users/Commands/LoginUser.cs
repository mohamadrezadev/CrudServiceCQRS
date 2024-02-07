using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Commands
{
    public class LoginUser:IRequest<loginDto>
    {
        public string Email { get; set;}
        public string Password { get; set;}
    }
    public class loginDto
    {
        public loginDto()
        {
            
        }
        public loginDto( SignInResult SignInResult , List<string> Roles )
        {
            this.Roles = Roles;
            this.SignInResult = SignInResult;
        }
        public SignInResult SignInResult { get; set; }
        public List<string> Roles { get; set;}
    }
}
