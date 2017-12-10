using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.ViewModels;
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

namespace ComcastStrataStore.Modules.ShoppingCart.Views
{
    /// <summary>
    /// Interaction logic for ShoppingCartView.xaml
    /// </summary>
    public partial class ShoppingCartView : UserControl, IShoppingCartView
    {
        public ShoppingCartView()
        {
            InitializeComponent();
        }


        public IViewModel ViewModel
        {
            get
            {
                return (IShoppingCartViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

    }
}
