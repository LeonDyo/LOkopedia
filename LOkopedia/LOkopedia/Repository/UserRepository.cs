using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace LOkopedia.Repository
{
    public class UserRepository
    {
        public static User getUser(String email, String password)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return(from user in db.Users
                        where user.UserEmail == email &&
                            user.UserPassword == password
                select user
            ).FirstOrDefault();
        }

        public static User getUserById(int userId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from user in db.Users
                        where user.UserId == userId
                    select user
                    ).FirstOrDefault();
        }

        public static Boolean getExistingUser(String email, String username)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            User u = (from user in db.Users
                    where user.UserEmail.Equals(email) || user.UserName.Equals(username)
                    select user).FirstOrDefault();
            return (u == null) ? false : true;
        }

        public static void createUser(String email, String password, String username, byte[] photo, DateTime dob, DateTime joinDate, String phone)
        {
            User user = UserFactory.create(email, password, username, photo, dob, joinDate, phone);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static Boolean updateUser(int userId, string userName, string userEmail, byte[] userPhoto, string userPhone)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            User user = (from u in db.Users
                            where u.UserId == userId
                        select u
                        ).FirstOrDefault();

            if (user == null) return false;
            
            if (userPhoto.Length != 0) user.UserPhoto = userPhoto;
            user.UserName = userName;
            user.UserEmail = userEmail;
            user.UserPhone = userPhone;
            db.SaveChanges();
            return true;
        }      
    }
}