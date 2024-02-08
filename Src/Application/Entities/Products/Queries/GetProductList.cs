﻿using Application.Entities.Dtos;
using Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Products.Queries
{
    public class GetProductList:IRequest<List<ProductDto>>
    {
    }
  
}
