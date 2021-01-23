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
    public partial class HistoryDetailPage : System.Web.UI.Page
    {
        private List<Product> productList;
        private List<HistoryDetail> detailList;
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

        private int getHistoryId()
        {
            return int.Parse(Request.QueryString["id"].ToString());
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

        private void setData()
        {
            productList = new List<Product>();
            detailList = getHistoryDetails();
            productList = getAllProduct();

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductPrice");
            dt.Columns.Add("ProductImage");
            dt.Columns.Add("Quantity");

            for (int i = 0; i < productList.Count; i++)
            {
                dt.Rows.Add(productList[i].ProductId, productList[i].ProductName, productList[i].ProductPrice.ToString(), ConvertToImage(productList[i].ProductImage), detailList[i].Quantity.ToString());
            }
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }

        private List<Product> getAllProduct()
        {
            List<HistoryDetail> cd = getHistoryDetails();
            List<Product> p = new List<Product>();

            foreach (HistoryDetail c in cd)
            {
                Product product = ProductRepository.getProductById(c.ProductId);
                p.Add(product);
            }
            return p;
        }

        private List<HistoryDetail> getHistoryDetails()
        {
            return HistoryRepository.getHistoryDetails(getHistoryId());
        }
    }
}