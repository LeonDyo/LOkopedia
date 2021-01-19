using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Repository
{
    public class CartRepository
    {
        public static Boolean createCart(int cartId, int userId)
        {
            Cart cart = CartFactory.create(cartId, userId);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Carts.Add(cart);
            db.SaveChanges();
            return true;
        }
    }
}