using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class CartFactory
    {

        public static Cart create(int cartId, int productId, int quantity)
        {
            Cart cartDetail = new Cart();
            cartDetail.CartId = cartId;
            cartDetail.ProductId = productId;
            cartDetail.Quantity = quantity;
            return cartDetail;
        }
    }
}