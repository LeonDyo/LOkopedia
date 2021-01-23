using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

        private void setData()
        {
            credentials = getCredentials();
            User user = getCurrentUser(credentials);

            String newDob = getDate(user.UserDob.ToString());
            String newJoin = getDate(user.JoinDate.ToString());
           
            myName.Text = user.UserName;
            nameInput.Value = user.UserName;
            emailInput.Value = user.UserEmail;
            phoneInput.Value = user.UserPhone;
            dob.Text = newDob;
            join.Text = newJoin;
            myPhoto.ImageUrl = ConvertToImage(user.UserPhoto);
            errorMessage.Visible = false;
        }

        private String getDate(String date)
        {
            String result = "";
            for(int i = 0; i < date.Length; i++)
            {
                if (i == 10) break;
                result += date[i];
            }
            return result;
        }

        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
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
                int credentialss = getCredentials();

            HttpPostedFile postedFile = myPicture.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);

            if(fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".png") || fileExtension.Equals(""))
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                updateUser(credentialss, userName, userEmail, bytes, userPhone);
            }
            else
            {
                errorMessage.Text = "Profile Image Extension must be '.jpg' or '.png'";
                errorMessage.Visible = true;
            }

        }

        private Boolean updateUser(int userId, string userName, string userEmail, byte[] userPhoto, string userPhone)
        {
            return UserRepository.updateUser(userId, userName, userEmail, userPhoto, userPhone);
        }
    }
}