using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class ProductFactory
    {
        public static Product Create(String ProductName, int ProductPrice, byte[] ProductImage, String ProductDescription, int categoryId, int userId, DateTime uploadDate)
        {
            Product product = new Product();
            product.ProductName = ProductName;
            product.ProductPrice = ProductPrice;
            product.ProductImage = ProductImage;
            product.ProductDescription = ProductDescription;
            product.ProductRating = 0;
            product.CategoryId = categoryId;
            product.UserId = userId;
            product.UploadDate = uploadDate;
            product.IsDeleted = 0;
            return product;
        }
    }
}