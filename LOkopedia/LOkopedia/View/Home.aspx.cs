using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class Guest : System.Web.UI.Page
    {
        private static Random rand;
        private List<Product> list;
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

        private static List<Product> getAll()
        {
            return ProductRepository.getAll();
        }

        private void setData()
        {
            list = new List<Product>();
            list = getAll();
            randomizeData(list);
         
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductPrice");
            dt.Columns.Add("ProductImage");

            for (int i = 0; i < list.Count; i++)
            {
                dt.Rows.Add(list[i].ProductId, list[i].ProductName, list[i].ProductPrice.ToString(), list[i].ProductImage);
            }

            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        private void randomizeData(List<Product> list)
        {
            rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Product value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}