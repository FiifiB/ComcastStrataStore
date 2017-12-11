using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreEDM;

namespace StoreDAL
{
    public class ShopOrderDAL : IShopOrderDAL
    {
        public void CreateOrder( ShopOrder order)
        {
            using (StoreEntities context = new StoreEntities())
            {
                context.ShopOrders.Add(order);
                context.SaveChanges();
            }
        }

        public List<ShopOrder> GetAllOrders(int id)
        {
            using (StoreEntities context = new StoreEntities())
            {
                var result = context.ShopOrders.Where(s => s.Customer_Id == id).ToList();
                return result;
            }
        }

        public ShopOrder GetOrderById(int id, int OrderId)
        {
            using (StoreEntities context = new StoreEntities())
            {
                var result = context.ShopOrders.Where(s => s.Customer_Id == id && s.Id == OrderId).FirstOrDefault();
                return result;
            }
        }

        public List<ShopOrder> GetOrderInDateRange(int id, DateTime from, DateTime to)
        {
            using (StoreEntities context = new StoreEntities())
            {
                var result = context.ShopOrders.Where(s => s.Purchase_Date >= from && s.Purchase_Date < to).ToList();
                return result;
            }
        }
    }
}
