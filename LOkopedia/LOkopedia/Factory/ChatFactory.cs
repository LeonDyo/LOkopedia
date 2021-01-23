using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class ChatFactory
    {
        public static Chat create(int roomId, int userId, String message, DateTime sendDate)
        {
            Chat chat = new Chat();
            chat.RoomId = roomId;
            chat.UserId = userId;
            chat.Message = message;
            chat.SendDate = sendDate;
            return chat;
        }
    }
}