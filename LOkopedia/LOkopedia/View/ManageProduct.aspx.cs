using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LOkopedia.View
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected static int category;
        protected int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            flag = 1;
        }

        protected void beverageBtn_Click(object sender, EventArgs e)
        {
            category = 1;
            productCategory.Text = "Beverages";
        }

        protected void fashionBtn_Click(object sender, EventArgs e)
        {
            category = 2;
            productCategory.Text = "Fashion";
        }

        protected void electronicBtn_Click(object sender, EventArgs e)
        {
            category = 3;
            productCategory.Text = "Electronic";
        }

        protected void beautyBtn_Click(object sender, EventArgs e)
        {
            category = 4;
            productCategory.Text = "Beauty";
        }

        protected void close_Click(object sender, EventArgs e)
        {
            flag = 0;
        }

        protected void DeleteBtn_Click(Object sender, EventArgs e)
        {
            LinkButton ads = sender as LinkButton;
            String a = ads.CommandArgument.ToString();
            System.Diagnostics.Debug.Write(a);
        }
    }
}