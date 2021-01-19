using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class UserFactory
    {
        public static User create(String email, String password, String username, String photo, DateTime dob, DateTime joinDate, String phone)
        {
            User user = new User();
            user.UserEmail = email;
            user.UserPassword = password;
            user.UserName = username;
            user.UserPhoto = photo;
            user.UserDob = dob;
            user.JoinDate = joinDate;
            user.UserPhone = phone;
            return user;
        }
    }
}