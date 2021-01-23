using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class RoomFactory
    {
        public static Room create(int firstUser, int secondUser)
        {
            Room room = new Room();
            room.FirstUserId = firstUser;
            room.SecondUserId = secondUser;
            return room;
        }
    }
}