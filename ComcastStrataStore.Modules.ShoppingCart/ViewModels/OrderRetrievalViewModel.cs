using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class OrderRetrievalViewModel : BindableBase, IOrderRetrievalViewModel
    {
        public IView View { get; set; }

        public OrderRetrievalViewModel(IOrderRetrievalView view)
        {
            View = view;
            View.ViewModel = this;
        }
    }
}
