using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace LOkopedia.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLogin()) Response.Redirect("/View/Home.aspx");
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        private User validateUser()
        {
            String email = emailInput.Text.ToString();
            String password = passInput.Text.ToString();
            User user = getUser(email, password);
            return (user != null) ? user : null;
        }

        protected void signIn_Click(object sender, EventArgs e)
        {
            if (emailInput.Text.IsEmpty() || passInput.Text.IsEmpty())
            {
                errorMsg.Text = "Please fill the empty field";
            }
            else
            {
                User user = validateUser();
                if (user != null) {
                    if (rememberMe.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("UserInfo");
                        cookie["User_ID"] = user.UserId.ToString();
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        Session["User_ID"] = user.UserId;
                    }
                        Response.Redirect("/View/Home.aspx");
                }
                else
                {
                    errorMsg.Text = "Wrong Credentials";
                    passInput.Text = "";
                }
            }
        }

        private User getUser(String email, String password)
        {
            return UserRepository.getUser(email, password);
        }
    }
}