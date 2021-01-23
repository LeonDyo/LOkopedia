using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace LOkopedia.View
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (isLogin()) setData();
                else Response.Redirect("/View/Login.aspx");
            }
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        private int getProductId()
        {
            return int.Parse(Request.QueryString["id"]);
        }

        private void setData()
        {
            Product product = getProduct(getProductId());
            myPhoto.ImageUrl = ConvertToImage(product.ProductImage);
            productName.Value = product.ProductName;
            productPrice.Value = product.ProductPrice.ToString();
            productDescription.Value = product.ProductDescription;
        }

        private string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }

        private Product getProduct(int productId)
        {
            return ProductRepository.getProductById(productId);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String name = productName.Value;
            String price = productPrice.Value.ToString();
            String description = productDescription.Value;

            if (!name.IsEmpty() && !price.IsEmpty() && !description.IsEmpty())
            {
                HttpPostedFile postedFile = productImage.PostedFile;
                string filename = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(filename);

                if (fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".png") || fileExtension.Equals(""))
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                    updateProduct(getProductId(), name, int.Parse(price), bytes, description);
                    errorMsg.Text = "Success save changes";
                    errorMsg.ForeColor = Color.Green;
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Text = "Product Image extension must be '.jpg' or '.png'";
                    errorMsg.Visible = true;
                }
            }
            else
            {
                errorMsg.Text = "Please fill the empty field";
                errorMsg.Visible = true;
            }
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            deleteProduct(getProductId());
        }

        private void deleteProduct(int productId)
        {
            ProductRepository.deleteProduct(productId);
            Response.Redirect("/View/ManageProduct.aspx");
        }

        private void updateProduct(int productId, String productName, int productPrice, byte [] productImage, String productDescription)
        {
            ProductRepository.updateProduct(productId, productName, productPrice, productImage, productDescription);
        }
    }
}