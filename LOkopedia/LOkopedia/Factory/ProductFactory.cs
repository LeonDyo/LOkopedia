using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class ProductFactory
    {
        public static Product Create(String ProductName, int ProductPrice, String ProductImage, String ProductDescription, float ProductRating)
        {
            Product product = new Product();
            product.ProductName = ProductName;
            product.ProductPrice = ProductPrice;
            product.ProductImage = ProductImage;
            product.ProductDescription = ProductDescription;
            product.ProductRating = ProductRating;
            return product;
        }
    }
}