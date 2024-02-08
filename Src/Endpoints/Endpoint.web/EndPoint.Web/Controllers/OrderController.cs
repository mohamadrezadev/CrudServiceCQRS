using Application.Baskets;
using Application.Entities.Dtos;
using Application.Entities.Orders.Commands;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;


namespace EndPoint.Web.Controllers
{
    [Authorize(Roles ="User")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
		private readonly Basket basket;

		public OrderController(IMediator mediator,  Basket basket)
        {
            _mediator = mediator;
			this.basket=basket;
			
        }
        public IActionResult Checkout( )
        {
			
			return View();
        }
        public async Task<IActionResult> MyOrder( )
        {
            //await _mediator.Send();
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Checkout( CheckoutViewModel model )
		{
			
			if (!basket.Items.Any())
			{
				ModelState.AddModelError("", "ther is not any item in the basket");
			}
			if (ModelState.IsValid)
			{
				var userIdString= HttpContext.User.FindFirstValue(claimType: ClaimTypes.NameIdentifier);
				Guid.TryParse(userIdString, out Guid userId);
				var order = new OrderDto
				{

					Name = model.Name,
					Address = model.Address,
					City = model.City,
					TootalPrice = basket.TotalPrice()

				};
				foreach (var item in basket.Items)
				{
					order.orderDetails.Add(new OrderDetailDto
					{
						Product = item.Product,
						Quantity = item.Quantity,
						
					});
				}
			    var result=	await _mediator.Send(new CreateOrder(userId, order));
				if (result)
				{
					basket.Clear();
					return RedirectToActionPermanent("MyOrder", "Account");
				}
		
			}
			return View(model);
		}

	}
}
