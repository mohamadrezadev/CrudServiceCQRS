﻿using Application.Entities.Dtos;
using Application.Entities.Orders.Commands;
using Application.Entities.Products.Commands;
using Application.Entities.Users.Commands;
using AutoMapper;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Domain.Entities.Users;
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
            CreateMap<Product,ProductDto >().ReverseMap();
            CreateMap<Product,UpdateProduct >().ReverseMap();

            CreateMap<RegisterUser,User >().ReverseMap();
            CreateMap<UserDto,User >().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            CreateMap<OrderDto, Order>()
          .ForMember(dest => dest.orderDetails, opt => opt.MapFrom(src => src.orderDetails));

            CreateMap<OrderDetailDto, OrderDetail>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));





        }
    }
}
