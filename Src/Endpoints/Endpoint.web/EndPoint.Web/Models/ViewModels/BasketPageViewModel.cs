using Application.Baskets;

namespace EndPoint.Web.Models.ViewModels
{
    public class BasketPageViewModel
    {
        public Basket Basket { get; set; }
        public string ReturnUrl { get; set; }
    }
}
