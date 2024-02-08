using Domain.Entities.Orders;

namespace Application.Entities.Dtos
{
    public class OrderDetailDto
    {
        public int Id { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}
