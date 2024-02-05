using Application.Entities.Orders.Commands;
using Application.Entities.Products.Commands;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public class Profiles  :Profile
    {
        public Profiles()
        {
            CreateMap<Order, CreateOrder>().ReverseMap();
            CreateMap<Order, DeleteOrder>().ReverseMap();
            
            CreateMap<Product,CreateProduct >().ReverseMap();

        }
    }
}
