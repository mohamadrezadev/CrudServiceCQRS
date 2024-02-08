using Application.Baskets;
using Application.Entities.Products.Queries;
using Application.Interface;
using EndPoint.Web.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistances.Repositories;

namespace EndPoint.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IMediator _mediator;
        private readonly Basket sessionBasket;

        public BasketController(IMediator mediator, Basket _sessionBasket )
        {
            _mediator = mediator;
           this.sessionBasket = _sessionBasket;
        }
        public IActionResult Index(string returnUrl )
        {
            BasketPageViewModel basketPageViewModel = new()
            {

                ReturnUrl = returnUrl,
                Basket =sessionBasket
            };
            return View(basketPageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddToBasket( int productId, string returnUrl )
        {
            var product=await _mediator.Send(new GetProductByid() { Id = productId });
            sessionBasket.Add(product, 1);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
          

        }
        public async Task<IActionResult> RemoveFromBasket( int productId, string returnUrl )
        {
            
            var product= await _mediator.Send(new GetProductByid() { Id=productId});
            sessionBasket.Remove(product);
            return RedirectToAction("Index", new { returnUrl = returnUrl });
        }
    }
}
