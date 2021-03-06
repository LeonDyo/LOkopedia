﻿using LOkopedia.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace LOkopedia.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected int flag;
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = 0;
        }

        protected void signIn_Click(object sender, EventArgs e)
        {
            String username = usernameInput.Text;
            String email = emailInput.Text;
            String password = passInput.Text;
            String phone = phoneInput.Text;
            String day = days.Value.ToString();
            String month = months.Value.ToString();
            String year = years.Value.ToString();
            DateTime joinDate = DateTime.Now;
            
         if (username.IsEmpty() || email.IsEmpty() || phone.IsEmpty() || day.IsEmpty() || month.IsEmpty() || year.IsEmpty())
            {
                errorMsg.Text = "Please fill the empty field !";
            }
            else
            {
                
                if (!email.EndsWith("@gmail.com") && !email.EndsWith("@yahoo.com"))
                {
                    errorMsg.Text = "Email format is not correct";
                    flag = 0;
                }
                else
                {
                    if (int.Parse(day) < 1 || int.Parse(day) > 31 || int.Parse(month) < 1 || int.Parse(month) > 12 || int.Parse(year) > 2021)
                    {
                        errorMsg.Text = "Date of Birth is not correct !";
                        flag = 0;
                    }
                    else
                    {
                        if (passInput.Text.ToString().Equals(confirm.Text.ToString()))
                        {
                            String temp = day + "/" + month + "/" + year;
                            DateTime dob = DateTime.Parse(temp);

                            if(!UserRepository.getExistingUser(email, username))
                            {
                                HttpPostedFile postedFile = myPicture.PostedFile;
                                string filename = Path.GetFileName(postedFile.FileName);
                                string fileExtension = Path.GetExtension(filename);

                                if (fileExtension.ToLower().Equals(".jpg") || fileExtension.ToLower().Equals(".png") || fileExtension.Equals(""))
                                {
                                    Stream stream = postedFile.InputStream;
                                    BinaryReader binaryReader = new BinaryReader(stream);
                                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                                    if(bytes.Length == 0)
                                    {
                                        errorMsg.Text = "Choose your profile picture";
                                        flag = 0;
                                    }
                                    else
                                    {
                                        UserRepository.createUser(email, password, username, bytes, dob, joinDate, phone);

                                        flag = 1;
                                        Response.Redirect("/View/Login.aspx");
                                    }
                                }
                                else
                                {
                                    errorMsg.Text = "Profile picture extension must be '.jpg' or '.png'";
                                    flag = 0;
                                }
                            }
                            else
                            {
                                errorMsg.Text = "User already exist !";
                                flag = 0;
                            }
                        }
                        else
                        {
                            errorMsg.Text = "Password not match";
                        }
                    }
                }
            }
        }
    }
}