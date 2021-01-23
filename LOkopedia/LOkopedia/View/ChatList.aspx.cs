using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class ChatList : System.Web.UI.Page
    {
        List<User> list;
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
            list = new List<User>();
            list = filterUser(getAllRoom(getUserId()));

            DataTable dt = new DataTable();
            dt.Columns.Add("UserId");
            dt.Columns.Add("UserName");
            dt.Columns.Add("UserPhoto");

            for (int i = 0; i < list.Count; i++)
            {
                dt.Rows.Add(list[i].UserId, list[i].UserName, ConvertToImage(list[i].UserPhoto));
            }
            
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }

        private List<User> filterUser(List<Room> roomList)
        {
            List<User> userList = new List<User>();

            int currUserID = getUserId();

            foreach(Room r in roomList)
            {
                if(r.FirstUserId == currUserID)
                    userList.Add(getUserById(r.SecondUserId));
                else
                    userList.Add(getUserById(r.FirstUserId));
            }
            return userList;
        }

        private User getUserById(int userId)
        {
            return UserRepository.getUserById(userId);
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

        private List<Room> getAllRoom(int userId)
        {
            return RoomRepository.getAllRoom(userId);
        }

        protected void chatBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Redirect("/View/ChatPage.aspx?user="+btn.CommandArgument.ToString());
        }
    }
}