using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class CustomerLoginViewModel: BindableBase, ICustomerLoginViewModel
    {
        public IView View { get; set; }
        private IRegionManager _regionManager;

        public CustomerLoginViewModel(ICustomerLoginView view, RegionManager regionManager)
        {
            View = view;
            View.ViewModel = this;
            _regionManager = regionManager;
        }
    }
}
