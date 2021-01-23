using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;

namespace LOkopedia.Repository
{
    public class ProductRepository
    {
        public static List<Product> getAll(int userId, int categoryId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            if(categoryId == 0)
            {
                return (from p in db.Products
                        where p.IsDeleted == 0 && p.UserId != userId
                        select p).ToList();
            }
            else
            {
                return (from p in db.Products
                        where p.IsDeleted == 0 && p.UserId != userId && p.CategoryId == categoryId
                        select p).ToList();
            }
        }

        public static List<Product> getSearch(String query)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            var regex = new Regex(query);
            return (from p in db.Products
                    where p.IsDeleted == 0
                        select p).Where(p => p.ProductName.Contains(query)
                   ).ToList();
        }

        public static List<Product> getAllByUser(int userId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from p in db.Products
                    where p.UserId == userId && p.IsDeleted == 0
                    select p).ToList();
        }

        public static Product getProductById(int productId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from p in db.Products
                        where p.ProductId == productId
                    select p).FirstOrDefault();
        }

        public static Boolean deleteProduct(int productId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            Product product = (from p in db.Products
                               where p.ProductId == productId
                               select p).FirstOrDefault();

            if (product == null) return false;

            product.IsDeleted = 1;
            db.SaveChanges();

            return true;
        }

        public static Boolean updateProduct(int productId, String productName, int productPrice, byte[] productImage, String productDescription)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            Product product = (from p in db.Products
                                    where p.ProductId == productId
                               select p).FirstOrDefault();

            if (product == null) return false;
            
            if (productImage.Length != 0) product.ProductImage = productImage;
            product.ProductName = productName;
            product.ProductPrice = productPrice;
            product.ProductDescription = productDescription;
            db.SaveChanges();
            
            return true;
        }

        public static void createProduct(String ProductName, int ProductPrice, byte[] ProductImage, String ProductDescription, int categoryId, int userId, DateTime uploadDate)
        {
            Product product = ProductFactory.Create(ProductName, ProductPrice, ProductImage, ProductDescription, categoryId, userId, uploadDate);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Products.Add(product);
            db.SaveChanges();

        }
    }
}