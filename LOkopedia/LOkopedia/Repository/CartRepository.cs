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

        public static void create(int cartId, int productId, int quantity)
        {
            Cart cartD = CartFactory.create(cartId, productId, quantity);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Carts.Add(cartD);
            db.SaveChanges();
        }

        public static Boolean updateCartDetail(int cartId, int productId, int quantity)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            Cart cd = (from c in db.Carts
                             where c.CartId == cartId && c.ProductId == productId
                             select c).FirstOrDefault();

            if (cd == null) return false;

            cd.Quantity += quantity;
            db.SaveChanges();
            return true;
        }

        public static Boolean removeDetail(int cartId, int productId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            Cart cd = (from c in db.Carts
                             where c.CartId == cartId && c.ProductId == productId
                             select c).FirstOrDefault();
            
            if (cd == null) return false;
            
            db.Carts.Remove(cd);
            db.SaveChanges();
            return true;
        }

        public static void removeAll(int cartId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            List<Cart> list = (from c in db.Carts
                                   where c.CartId == cartId
                                   select c).ToList();
            foreach(Cart c in list)
            {
                db.Carts.Remove(c);
            }
                db.SaveChanges();
        }

        public static Cart getCart(int userId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from c in db.Carts
                    where c.CartId == userId
                    select c).FirstOrDefault();
        }

        public static Cart getDuplicate(int userId, int productId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            Cart cart =  (from c in db.Carts
                    where c.CartId == userId
                    select c).FirstOrDefault();
            if (cart == null) return null;
            return (from cd in db.Carts
                    where cd.CartId == cart.CartId &&
                        cd.ProductId == productId
                    select cd).FirstOrDefault();
        }

        public static List<Cart> getCartDetail(int cartId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from c in db.Carts
                             where c.CartId == cartId
                             select c).ToList();
        }
    }
}