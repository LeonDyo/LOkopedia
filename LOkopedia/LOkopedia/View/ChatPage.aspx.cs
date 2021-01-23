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
    public partial class ChatPage : System.Web.UI.Page
    {
        List<Chat> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLogin())
            {
                if (!isRoomExist()) createNewRoom();
                setData();
            }
            else
            {
                Response.Redirect("/View/Login.aspx");
            }
        }

        public int getSellerId()
        {
            return int.Parse(Request.QueryString["user"]);
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
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

        private Boolean isRoomExist()
        {
            return (RoomRepository.getRoom(getUserId(), getSellerId()) != null) ? true : false;
        }

        protected void sendBtn_Click(object sender, ImageClickEventArgs e)
        {
            sendChat(getRoomId(getSellerId(), getUserId()), getUserId(), chatField.Value.ToString(), DateTime.Now);
        }

        private void setData()
        {
            list = new List<Chat>();
            list = getAll();

            DataTable dt = new DataTable();
            dt.Columns.Add("ChatId");
            dt.Columns.Add("UserName");
            dt.Columns.Add("SendDate");
            dt.Columns.Add("Message");

            for (int i = 0; i < list.Count; i++)
            {
                User user = getUserById(list[i].UserId);
                dt.Rows.Add(list[i].ChatId, user.UserName, list[i].SendDate.ToString(), list[i].Message);
            }
            setSellerProfile();
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        private void setSellerProfile()
        {
            User user = getUserById(getSellerId());
            sellerName.Text = user.UserName;
            sellerPhoto.ImageUrl = ConvertToImage(user.UserPhoto);
        }
        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }

        private User getUserById(int userId)
        {
            return UserRepository.getUserById(userId);
        }

        private List<Chat> getAll()
        {
            return ChatRepository.getAll(getRoomId(getUserId(), getSellerId()));
        }

        private int getRoomId(int firstUser, int secondUser)
        {
            return RoomRepository.getRoom(firstUser, secondUser).RoomId;
        }

        private void sendChat(int roomId, int userId, String message, DateTime sendDate)
        {
            ChatRepository.create(roomId, userId, message, sendDate);
            chatField.Value = "";
            Response.Redirect("/View/ChatPage.aspx?user="+getSellerId());
        }

        private void createNewRoom()
        {
            RoomRepository.createRoom(getUserId(), getSellerId());
        }
    }
}