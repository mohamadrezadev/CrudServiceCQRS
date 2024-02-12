using Application.Interface.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Users.Commands
{
    public class LoginUserValidator:AbstractValidator<LoginUser>
    {
        public LoginUserValidator( )
        {
             RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Email Can not null");  
        }
    }
}
