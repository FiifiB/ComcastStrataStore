using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.UIEntities
{
    public class ShopOrderEntity : BindableBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private int customerId;

        public int CustomerIde
        {
            get { return customerId; }
            set { SetProperty(ref customerId, value); }
        }

        private double totalCost;

        public double TotalCost
        {
            get { return totalCost; }
            set { SetProperty(ref totalCost, value); }
        }

        private DateTime purchaseDate;

        public DateTime PurchaseDate
        {
            get { return purchaseDate; }
            set { SetProperty(ref purchaseDate, value); }
        }

        private ObservableCollection<ProductEntity> products;

        public ObservableCollection<ProductEntity> Products
        {
            get { return products; }
            set { SetProperty(ref products, value); }
        }

    }
}
