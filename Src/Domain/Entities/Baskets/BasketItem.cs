using Domain.Entities.Products;

namespace Domain.Entities.Baskets
{
    public class BasketItem
    {

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
