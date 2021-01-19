using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class MyProfile : System.Web.UI.Page
    {
        private int credentials;
        public User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (isLogin()) setData();
                else Response.Redirect("/View/Login.aspx");
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        private void setData()
        {
            credentials = getCredentials();
            User user = getCurrentUser(credentials);

            myPhoto.ImageUrl = user.UserPhoto;
            myName.Text = user.UserName;
            nameInput.Value = user.UserName;
            emailInput.Value = user.UserEmail;
            phoneInput.Value = user.UserPhone;
            dob.Text = user.UserDob.ToString();
            join.Text = user.JoinDate.ToString();
        }

        private User getCurrentUser(int userId)
        {
            return UserRepository.getUserById(userId);
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

        protected void Save_Click(object sender, EventArgs e)
        {
                string userName = nameInput.Value;
                string userEmail = emailInput.Value;
                string userPhone = phoneInput.Value;
                System.Diagnostics.Debug.Write(userName);
                updateUser(credentials, userName, userEmail, "https://cdn.idntimes.com/content-images/post/20200915/em3-pjfvuaekuha-f9e2841fad1c1f1fad5433c280c75b70_600x400.jpg", userPhone);
        }

        private Boolean updateUser(int userId, string userName, string userEmail, string userPhoto, string userPhone)
        {
            return UserRepository.updateUser(userId, userName, userEmail, userPhoto, userPhone);
        }
    }
}