using LOkopedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOkopedia.Factory
{
    public class HistoryFactory
    {
        public static History create(int userId)
        {
            History history = new History();
            history.UserId = userId;
            history.HistoryDate = DateTime.Now;
            return history;
        }

        public static HistoryDetail createDetail(int historyId, int productId, int quantity)
        {
            HistoryDetail detail = new HistoryDetail();
            detail.HistoryId = historyId;
            detail.ProductId = productId;
            detail.Quantity = quantity;
            return detail;
        }
    }
}