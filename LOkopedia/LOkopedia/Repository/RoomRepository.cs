using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace LOkopedia.Repository
{
    public class RoomRepository
    {
        public static void createRoom(int firstUser, int secondUser)
        {
            Room room = RoomFactory.create(firstUser, secondUser);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public static Room getRoom(int firstUser, int secondUser) {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from r in db.Rooms
                    where r.FirstUserId == firstUser && r.SecondUserId == secondUser ||
                        r.FirstUserId == secondUser && r.SecondUserId == firstUser
                    select r).FirstOrDefault();
        }

        public static List<Room> getAllRoom(int userID)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from r in db.Rooms
                    where r.FirstUserId == userID || r.SecondUserId == userID
                    select r).ToList();
        }
    }
}