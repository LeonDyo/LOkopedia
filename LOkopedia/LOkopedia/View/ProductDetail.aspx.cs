using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        protected int flag = 0;
        protected int qty;
        private int rating = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLogin()) setData();
            else Response.Redirect("/View/Login.aspx");
        }

        private void setData()
        {
            Product p = getData();

            productImage.ImageUrl = p.ProductImage;
            productName.Text = p.ProductName;
            productPrice.Text = "₩ " + p.ProductPrice.ToString();
            description.Text = p.ProductDescription;
            ratingView.Text = p.ProductRating.ToString();
            rating = (int)Math.Round(p.ProductRating);
        }

        protected int getRating()
        {
            return rating;
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        private Product getData()
        {
            int id = getProductId();
            return ProductRepository.getProductById(id);
        }

        private int getProductId()
        {
            return int.Parse(Request.QueryString["id"]);
        }

        protected void descriptionBtn_Click(object sender, EventArgs e)
        {
            flag = 1;
            descriptionBtn.ForeColor = Color.Turquoise;
            forumBtn.ForeColor = Color.Gray;
        }

        protected void forumBtn_Click(object sender, EventArgs e)
        {
            flag = 2;
            descriptionBtn.ForeColor = Color.Gray;
            forumBtn.ForeColor = Color.Turquoise;
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            User user = getCurrentUser();

            System.Diagnostics.Debug.WriteLine(quantity.Text +" " + user.UserId + " " + int.Parse(Request.QueryString["id"]));
        }
        
        private User getCurrentUser()
        {
            return UserRepository.getUserById(getUserId());
        }
        private int getUserId()
        {
            int ID = -1;
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (Session["User_ID"] == null) ID = int.Parse(cookie["User_ID"].ToString());
            else if (cookie == null) ID = int.Parse(Session["User_ID"].ToString());
            else Response.Redirect("/View/Login.aspx");
            return ID;
        }
    }
}