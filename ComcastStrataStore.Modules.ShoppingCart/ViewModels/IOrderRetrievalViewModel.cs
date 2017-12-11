using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using Prism.Commands;
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

        string IdTextBox { get; set; }

        DateTime FromSelectedDate { get; set; }
        DateTime ToSelectedDate { get; set; }

        //Command to search for order by Id
        DelegateCommand SearchByIdCommand { get; set; }

        //Command to search for order by  Date Range
        DelegateCommand SearchByDateRangeCommand { get; set; }

        DelegateCommand GetAllOrdersCommand { get; set; }

        //Method to return an order by its id
        void GetOrderById();

        //Method to get order by date range
        void GetOrderByDateRange();

        //Method to get all orders by User
        void GetAllOrdersByUser();

        //Call back for receiving message with user data
        void RecieveAccountInfo(CustomerEntity customerEntity);
    }
}
