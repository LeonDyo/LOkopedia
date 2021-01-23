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
    public partial class MyCart : System.Web.UI.Page
    {
        private List<Product> productList;
        private List<Cart> detailList;
        protected static int flag = 0;

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
            productList = new List<Product>();
            detailList = getCartDetails();
            productList = getAllProduct();
            flag = detailList.Count;


            if(productList.Count != 0)
            {
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

        }

        public string ConvertToImage(byte[] imageBytes)
        {
            string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            return ImageUrl;
        }

        private List<Product> getAllProduct()
        {
            List<Cart> cd = getCartDetails();
            List<Product> p = new List<Product>();

            foreach(Cart c in cd){
                Product product = ProductRepository.getProductById(c.ProductId);
                p.Add(product);
            }
            return p;
        }

        private List<Cart> getCartDetails()
        {
            return CartRepository.getCartDetail(getUserId());
        }
        private int getUserId()
        {
            int ID = -1;
            HttpCookie cookie = Request.Cookies["UserInfo"];

            if (Session["User_ID"] == null) ID = int.Parse(cookie["User_ID"].ToString());
            else if (cookie == null) ID = int.Parse(Session["User_ID"].ToString());
            return ID;
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = int.Parse(btn.CommandArgument.ToString());

            CartRepository.removeDetail(getUserId(), productId);
            Response.Redirect("/View/MyCart.aspx");
        }

        protected void checkOutBtn_Click(object sender, EventArgs e)
        {
            createHistory();
            CartRepository.removeAll(getUserId());
            Response.Redirect("/View/Home.aspx?id=0");
        }

        private void createHistory()
        {
            HistoryRepository.create(getUserId());
            List<History> all = HistoryRepository.getAll(getUserId());
            int historyId = all.Max(t => t.HistoryId);
            createHistoryDetail(historyId);
        }

        private void createHistoryDetail(int historyId)
        {
            List<Cart> currentCart = getCartDetails();
            
            foreach(Cart c in currentCart)
            {
                HistoryRepository.createDetail(historyId, c.ProductId, c.Quantity);
            }
        }
    }
}