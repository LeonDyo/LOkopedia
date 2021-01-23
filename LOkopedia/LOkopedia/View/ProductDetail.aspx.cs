using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
        List<ForumDetail> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (isLogin()) {
                setData();
                setForum();
            } 
            else Response.Redirect("/View/Login.aspx");
        }

        private void setData()
        {
            Product p = getData();

            productImage.ImageUrl = ConvertToImage(p.ProductImage);
            productName.Text = p.ProductName;
            productPrice.Text = "₩ " + p.ProductPrice.ToString();
            description.Text = p.ProductDescription;
            uploadDate.Text = getDate(p.UploadDate.ToString());
            //if (p.ProductRating == 0) ratingView.Text = "No rating";
            //else ratingView.Text = p.ProductRating.ToString();
            rating = (int)Math.Round(p.ProductRating);
        }

        private String getDate(String date)
        {
            String result = "";
            for (int i = 0; i < date.Length; i++)
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
            if(int.Parse(quantity.Text) <= 0)
            {
                errorMessage.Text = "Quantity must greater than 0";
                errorMessage.Visible = true;
            }
            else
            {
                    if (CartRepository.getDuplicate(user.UserId, int.Parse(Request.QueryString["id"])) == null)
                        CartRepository.create(user.UserId, int.Parse(Request.QueryString["id"]), int.Parse(quantity.Text));
                    else
                        CartRepository.updateCartDetail(user.UserId, int.Parse(Request.QueryString["id"]), int.Parse(quantity.Text));

                errorMessage.Text = "Added to your cart . . .";
                errorMessage.ForeColor = Color.Green;
                errorMessage.Visible = true;
            }
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

        private User getUserById(int userId)
        {
            return UserRepository.getUserById(userId);
        }

        private void setForum()
        {
            list = new List<ForumDetail>();
            list = getForumDetailList(getProductId());

            DataTable dt = new DataTable();
            dt.Columns.Add("ForumId");
            dt.Columns.Add("UserName");
            dt.Columns.Add("UserPhoto");
            dt.Columns.Add("Review");
            dt.Columns.Add("PostDate");

            for (int i = 0; i < list.Count; i++)
            {
                User user = getUserById(list[i].UserId);
                dt.Rows.Add(list[i].ForumId, user.UserName, ConvertToImage(user.UserPhoto), list[i].Review, getDate(list[i].PostDate.ToString()));
            }
            setAnonim();
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        private void setAnonim()
        {
            User user = getCurrentUser();
            anonim.Text = user.UserName;
            anonimImage.ImageUrl = ConvertToImage(user.UserPhoto);
        }

        private List<ForumDetail> getForumDetailList(int forumId){
            return ForumRepository.getForumDetails(forumId);
        }

        protected void sendBtn_Click(object sender, EventArgs e)
        {
            if (!forumField.Text.Equals(""))
            {
                if(ForumRepository.getForum(getProductId()) == null)
                {
                    ForumRepository.createForum(getProductId());
                    ForumRepository.createForumDetail(getProductId(), getCurrentUser().UserId, forumField.Text.ToString(), DateTime.Now);
                }
                else
                {
                    ForumRepository.createForumDetail(getProductId(), getCurrentUser().UserId, forumField.Text.ToString(), DateTime.Now);
                }
                Response.Redirect("/View/ProductDetail.aspx?id="+getProductId().ToString());
            }
            else
            {
                flag = 2;
                errorMsg.Visible = true;
            }
        }

        protected void chatBtn_Click(object sender, ImageClickEventArgs e)
        {
            Product product = ProductRepository.getProductById(getProductId());
            Response.Redirect("/View/ChatPage.aspx?user="+product.UserId.ToString());
        }
    }
}