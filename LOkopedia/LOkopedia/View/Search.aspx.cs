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
    public partial class Search : System.Web.UI.Page
    {
        private List<Product> list;
        protected static int flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            setData();
        }

        private List<Product> getProduct(String regex)
        {
            return ProductRepository.getSearch(regex);
        }

        private String getQuery()
        {
            return Request.QueryString["query"];
        }

        private void setData()
        {
            list = new List<Product>();
            list = getProduct(getQuery());

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductPrice");
            dt.Columns.Add("ProductImage");

            flag = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                dt.Rows.Add(list[i].ProductId, list[i].ProductName, list[i].ProductPrice.ToString(), ConvertToImage(list[i].ProductImage));
            }

            ListView1.DataSource = dt;
            ListView1.DataBind();
        }

        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }
    }
}