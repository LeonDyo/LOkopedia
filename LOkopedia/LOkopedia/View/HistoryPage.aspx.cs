using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class HistoryPage : System.Web.UI.Page
    {
        List<History> list;

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
            list = new List<History>();
            list = getAll();

            DataTable dt = new DataTable();
            dt.Columns.Add("HistoryId");
            dt.Columns.Add("HistoryDate");

            for (int i = 0; i < list.Count; i++)
            {
                dt.Rows.Add(list[i].HistoryId, list[i].HistoryDate);
            }

            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        private int getUserId()
        {
            int ID = -1;
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (Session["User_ID"] == null) ID = int.Parse(cookie["User_ID"].ToString());
            else if (cookie == null) ID = int.Parse(Session["User_ID"].ToString());
            return ID;
        }


        private List<History> getAll()
        {
            return HistoryRepository.getAll(getUserId());
        }

        protected void detailBtn_Click(object sender, EventArgs e)
        {
            Button tb = (Button)sender;
            Response.Redirect("/View/HistoryDetailPage.aspx?id=" + tb.CommandArgument.ToString());
        }
    }
}