﻿namespace Application.Entities.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string imageURl { get; set; }

    }
}
