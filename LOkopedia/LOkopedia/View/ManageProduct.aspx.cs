using LOkopedia.Model;
using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace LOkopedia.View
{
    public partial class ManageProduct : System.Web.UI.Page
    {
        protected static int category = 0;
        protected int flag = 0;
        private List<Product> list;
        protected static int id;
        protected static int count;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (isLogin())
                {
                    id = getCredentials();
                    setData();
                }
                else Response.Redirect("/View/Login.aspx");
            }
        }

        private Boolean isLogin()
        {
            HttpCookie cookie = Request.Cookies["UserInfo"];
            return (Session["User_ID"] != null || cookie != null) ? true : false;
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            flag = 1;
        }

        protected void close_Click(object sender, EventArgs e)
        {
            flag = 0;
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

        private static List<Product> getAll()
        {
            return ProductRepository.getAllByUser(id);
        }

        private void setData()
        {
            list = new List<Product>();
            list = getAll();

            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("ProductPrice");
            dt.Columns.Add("ProductImage");

            count = list.Count;
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

        protected void DeleteBtn_Click(Object sender, EventArgs e)
        {
            LinkButton ads = sender as LinkButton;
            String a = ads.CommandArgument.ToString();
            System.Diagnostics.Debug.Write(a);
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
                 flag = 1;
                 String name = productName.Value;
                 String description = productDescription.Value;
                 int category = int.Parse(DropDownList1.SelectedValue.ToString());
                 int userID = getCredentials();
                 DateTime uploadDate = DateTime.Now;



            if (!name.IsEmpty() && !productPrice.Value.ToString().IsEmpty() && !description.IsEmpty())
            {
                int price = int.Parse(productPrice.Value.ToString());
                if (!category.Equals(0))
                {
                    HttpPostedFile postedFile = productImage.PostedFile;
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fileExtension = Path.GetExtension(filename);

                    if (fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".png") || fileExtension.Equals(""))
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        if(bytes.Length == 0)
                        {
                            errorMsg.Text = "Please choose your product image";
                            errorMsg.Visible = true;
                        }
                        else
                        {
                            addProduct(name, price, bytes, description, category, userID, uploadDate);
                            Response.Redirect("/View/ManageProduct.aspx");
                        }
                    }
                    else
                    {
                        errorMsg.Text = "Product Image Extension must be '.jpg' or '.png'";
                        errorMsg.Visible = true;
                    }
                }
                else
                {
                    errorMsg.Text = "Please choose the category of the product";
                    errorMsg.Visible = true;
                }
            }
            else
            {
                errorMsg.Text = "Please fill the empty field";
                errorMsg.Visible = true;
            }
        }

        private void addProduct(String ProductName, int ProductPrice, byte[] ProductImage, String ProductDescription, int categoryId, int userId, DateTime uploadDate)
        {
            ProductRepository.createProduct(ProductName, ProductPrice, ProductImage, ProductDescription, categoryId, userId, uploadDate);
        }
    }
}