using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia
{
    public partial class masterpage : System.Web.UI.MasterPage
    {

        private int credentials;
        protected Boolean flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = isPageFull();
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (Session["User_ID"] != null || cookie != null)
            {
                setProfile();
            }
            manageComponent();
        }

        private Boolean isPageFull()
        {
            String path = HttpContext.Current.Request.Url.AbsolutePath;
            if (path.Equals("/View/Login.aspx") || path.Equals("/View/Register.aspx")) return false;
            return true;
        }

        public Boolean getID()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        private void manageComponent()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            if (Session["User_ID"] == null && cookie == null)
            {
                myCart.Visible= false;
                myPhoto.Visible = false;
                login.Visible = true;
                register.Visible = true;
            }
            else
            {
                myCart.Visible = true;
                myPhoto.Visible = true;
                login.Visible = false;
                register.Visible = false;
            }
        }

        private void setProfile()
        {
            credentials = getCredentials();
            User user = getCurrentUser(credentials);
            myName.Text = user.UserName;
            myPhoto.ImageUrl = user.UserPhoto;
        }

        private int getCredentials()
        {
            int ID = -1;
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (Session["User_ID"] == null) ID = int.Parse(cookie["User_ID"].ToString());
            else if (cookie == null) ID = int.Parse(Session["User_ID"].ToString());
            else Response.Redirect("/View/Login.aspx");
            return ID;
        }

        private User getCurrentUser(int userId)
        {
            return UserRepository.getUserById(userId);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Login.aspx");
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Register.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("User_ID");
            Session.RemoveAll();
            
            HttpCookie cookie = new HttpCookie("UserInfo");
            cookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(cookie);
            
            Response.Redirect("/View/Login.aspx");
        }

        protected void myProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/MyProfile.aspx");
        }

        protected void Instagram_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://web.facebook.com/");
        }

        protected void Facebook_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://web.instagram.com/");
        }

        protected void Twitter_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://web.twitter.com/");
        }

        protected void logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/Home.aspx");
        }

        protected void category_Click(object sender, EventArgs e)
        {

        }

        protected void myProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("/View/ManageProduct.aspx?id="+credentials.ToString());
        }
    }
}