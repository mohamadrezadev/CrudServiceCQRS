﻿using Domain.Entities.Products;
using MediatR;

namespace Application.Entities.Products.Queries
{
    public class GetProductByid :IRequest<Product>
    {
        public int Id { get; set; }
    }
}
