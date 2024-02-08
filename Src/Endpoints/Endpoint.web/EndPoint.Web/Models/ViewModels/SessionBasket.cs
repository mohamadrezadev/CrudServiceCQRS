using Application.Baskets;
using Domain.Entities.Products;
using Application.Extentions;
using Application.Entities.Dtos;

namespace EndPoint.Web.Models.ViewModels
{
    public class SessionBasket : Basket
    {
        private ISession _session;

        public static SessionBasket GetBasket( IServiceProvider service )
        {
            var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            SessionBasket basket = session.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket._session = session;

            return basket;
        }
        public override void Add( ProductDto product, int quantity )
        {
            base.Add(product, quantity);
            _session.SetJson("Basket", this);
        }
        public override void Remove( ProductDto product )
        {
            base.Remove(product);

            _session.SetJson("Basket", this);

        }
        public override void Clear( )
        {
            base.Clear();
            _session.Remove("Basket");
        }
    }
}
