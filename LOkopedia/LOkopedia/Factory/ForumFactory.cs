using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class ForumFactory
    {
        public static Forumm createForum(int productId)
        {
            Forumm forum = new Forumm();
            forum.ForumId = productId;
            forum.ProductId = productId;
            return forum;
        }

        public static ForumDetail createForumDetail(int forumId, int userId, String review, DateTime postDate)
        {
            ForumDetail forumDetail = new ForumDetail();
            forumDetail.ForumId = forumId;
            forumDetail.UserId = userId;
            forumDetail.Review = review;
            forumDetail.PostDate = postDate;
            return forumDetail;
        }
    }
}