namespace Application.Entities.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double TootalPrice { get; set; }
        public List<OrderDetailDto> orderDetails { get; set; } = new List<OrderDetailDto>();
      
    }
}
