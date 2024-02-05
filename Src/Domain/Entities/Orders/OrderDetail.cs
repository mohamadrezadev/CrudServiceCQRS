using Domain.Entities.Products;

namespace Domain.Entities.Orders
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
