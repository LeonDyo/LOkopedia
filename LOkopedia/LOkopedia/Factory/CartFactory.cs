using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class CartFactory
    {
        public static Cart create(int cartId, int userId)
        {
            Cart cart = new Cart();
            cart.CartId = "C00" + cartId;
            cart.UserId = userId;
            return cart;
        }
    }
}