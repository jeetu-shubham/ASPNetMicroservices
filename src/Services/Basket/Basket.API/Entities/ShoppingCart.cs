﻿using System.Collections.Generic;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShopingCartItem> Items { get; set; } = new List<ShopingCartItem>();

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal tolalPrice = 0;
                foreach (var item in Items)
                {
                    tolalPrice += item.Price + item.Quatity;
                }
                return tolalPrice;
            }
        }
    }
}
