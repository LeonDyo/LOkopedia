using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace LOkopedia.Repository
{
    public class ChatRepository
    {
        public static void create(int roomId, int userId, String message, DateTime sendDate)
        {
            Chat chat = ChatFactory.create(roomId, userId, message, sendDate);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Chats.Add(chat);
            db.SaveChanges();
        }

        public static List<Chat> getAll(int roomId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from c in db.Chats
                    where c.RoomId == roomId
                    select c).ToList();
        }
    }
}