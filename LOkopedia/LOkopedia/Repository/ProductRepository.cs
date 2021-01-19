using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Repository
{
    public class ProductRepository
    {
        public static List<Product> getAll()
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return db.Products.ToList();
        }

        public static Product getProductById(int productId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from p in db.Products
                        where p.ProductId == productId
                    select p).FirstOrDefault();
        }
    }
}