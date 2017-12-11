using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.UIEntities
{
    public class ProductEntity : BindableBase
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

        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { SetProperty(ref unitPrice, value); }
        }

        private Nullable<int> shopOrderId;

        public Nullable<int> ShopOrderId
        {
            get { return shopOrderId; }
            set { SetProperty(ref shopOrderId, value); }
        }

    }
}
