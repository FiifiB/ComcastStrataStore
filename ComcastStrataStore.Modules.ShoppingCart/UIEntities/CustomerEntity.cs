using ComcastStrataStore.Modules.ShoppingCart.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.UIEntities
{
    public class CustomerEntity : BindableBase
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string emial;

        public string Email
        {
            get { return emial; }
            set { SetProperty(ref emial, value); }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            set { SetProperty(ref balance, value); }
        }

        private CustomerLoyaltyType loyaltyStatus;

        public CustomerLoyaltyType LoyaltyStatus
        {
            get { return loyaltyStatus; }
            set { SetProperty(ref loyaltyStatus, value); }
        }

        private double spend;

        public double Spend
        {
            get { return spend; }
            set { SetProperty(ref spend, value); }
        }




    }
}
