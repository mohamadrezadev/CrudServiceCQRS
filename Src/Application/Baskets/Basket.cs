﻿using Application.Entities.Dtos;
using Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets;

public class Basket
{
    private List<BasketItem> _items = new();

    public virtual void Add( ProductDto product, int quantity )
    {
        var basketItem = _items.Where(c => c.Product.Id == product.Id).FirstOrDefault();
        if (basketItem != null)
        {
            basketItem.Quantity += quantity;
        }
        else
        {
            _items.Add(new BasketItem
            {
                Product = product,
                Quantity = quantity
            });
        }
    }

    public virtual void Remove( ProductDto product ) =>
        _items.RemoveAll(c => c.Product.Id == product.Id);

    public int TotalPrice( ) =>
        _items.Sum(c => c.Product.Price * c.Quantity);

    public virtual void Clear( ) => _items.Clear();

    public IEnumerable<BasketItem> Items => _items;
}
