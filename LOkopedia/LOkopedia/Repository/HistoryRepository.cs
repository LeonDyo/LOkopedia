using LOkopedia.Factory;
using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI.WebControls;

namespace LOkopedia.Repository
{
    public class HistoryRepository
    {
        public static void create(int cartId)
        {
            History history = HistoryFactory.create(cartId);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.Histories.Add(history);
            db.SaveChanges();
        }

        public static void createDetail(int historyId, int productId, int quantity)
        {
            HistoryDetail detail = HistoryFactory.createDetail(historyId, productId, quantity);
            LOkopediaEntities1 db = new LOkopediaEntities1();
            db.HistoryDetails.Add(detail);
            db.SaveChanges();
        }

        public static List<History> getAll(int userId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from h in db.Histories
                    where h.UserId == userId
                    select h).ToList();
        }

        public static List<HistoryDetail> getHistoryDetails(int historyId)
        {
            LOkopediaEntities1 db = new LOkopediaEntities1();
            return (from d in db.HistoryDetails
                    where d.HistoryId == historyId
                    select d).ToList();
        }
    }
}