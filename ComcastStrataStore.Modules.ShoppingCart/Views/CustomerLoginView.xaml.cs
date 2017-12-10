using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.ViewModels;

namespace ComcastStrataStore.Modules.ShoppingCart.Views
{
    /// <summary>
    /// Interaction logic for CustomerLoginView.xaml
    /// </summary>
    public partial class CustomerLoginView : UserControl, ICustomerLoginView
    {
        public CustomerLoginView()
        {
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get
            {
                return (ICustomerLoginViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}
