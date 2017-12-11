using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using StoreEDM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public interface IOrderRetrievalViewModel : IViewModel
    {
        //A list of Customer Orders to be displayed
        ObservableCollection<ShopOrderEntity> UserOrders { get; set; }

        //Method to return an order by its id
        void GetOrderById(int id);

        //Method to get order by date range
        void GetOrderByDateRange(int id, DateTime from, DateTime to);

        //Method to get all orders by User
        void GetAllOrdersByUser(int id);
    }
}
