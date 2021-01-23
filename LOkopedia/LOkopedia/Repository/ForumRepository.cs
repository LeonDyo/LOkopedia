using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace LOkopedia.Repository
{
    public class ForumRepository
    {
        public static void createForum(int productId)
        {
            Forumm forum = ForumFactory.createForum(productId);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Forumms.Add(forum);
            db.SaveChanges();
        }

        public static void createForumDetail(int forumId, int userId, String review, DateTime postDate)
        {
            ForumDetail forumDetail = ForumFactory.createForumDetail(forumId, userId, review, postDate);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.ForumDetails.Add(forumDetail);
            db.SaveChanges();
        }

        public static Forumm getForum(int forumId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from f in db.Forumms
                    where f.ForumId == forumId
                    select f).FirstOrDefault();
        }

        public static List<ForumDetail> getForumDetails(int forumId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from f in db.ForumDetails
                    where f.ForumId == forumId
                    select f).ToList();
        }
    }
}