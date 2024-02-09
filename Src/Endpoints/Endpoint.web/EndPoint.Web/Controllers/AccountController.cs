using Application.Entities.Orders.Queries;
using Application.Entities.Users.Commands;
using Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NuGet.Protocol;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EndPoint.Web.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
        
            _mediator = mediator;
        }
        public IActionResult login( )
        {
            return View();
        }
        public IActionResult signup( )
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signup(RegisterVM model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           var result= await _mediator.Send(new RegisterUser()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.UserName,
                PhoneNumber = model.Phone,
                Rolename = "User",
                FirstName=model.UserName,
                LastName=model.UserName,
            });
            if (result.Erors ==null )
            {
                return RedirectToAction(nameof(login));
            }

            ModelState.AddModelError("", $"{result.Erors}");
            return View(model);
        }

		[Authorize]
		public async Task<IActionResult> logout( CancellationToken cancellationToken)
		{
            await _mediator.Send(new LogoutUser(), cancellationToken);

			    return RedirectToAction("Index","Home");
		}

		[HttpPost]
        public async Task<IActionResult> Login( LoginVM model )
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var Resultlogin = await _mediator.Send(new LoginUser()
                {
                    Email = model.Email,
                    Password = model.Password,
                });
                if (Resultlogin.SignInResult is not null  )
                {
					if (!Resultlogin.SignInResult.Succeeded)
					{

						ModelState.AddModelError("", "Try Again");
						return View(model);

					}
					if (Resultlogin.Roles.Any(p => p.Equals("Admin")))
					{
						return RedirectToAction("Index", "Admin");
					}

					return RedirectToAction("Index", "Home");
				
                }
				ModelState.AddModelError("", "Email and password not correct");
				return View(model);

			}

        }
       
        [Authorize]
        public async Task<IActionResult> Profile( )
        {
            return View();
        }
		[Authorize]
		public async Task<IActionResult> MyOrder( )
        {
            var userIdString = HttpContext.User.FindFirstValue(claimType: ClaimTypes.NameIdentifier);
            Guid.TryParse(userIdString, out Guid userId);
           var result= await _mediator.Send(new GetOrdersUserById() { UserId=userId});
            return View(result);
        }

       




      
    }
}
