using ComcastStrataStore.Infrastructure;
using ComcastStrataStore.Modules.ShoppingCart.Models;
using ComcastStrataStore.Modules.ShoppingCart.Services;
using ComcastStrataStore.Modules.ShoppingCart.UIEntities;
using ComcastStrataStore.Modules.ShoppingCart.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace ComcastStrataStore.Modules.ShoppingCart.ViewModels
{
    public class ShoppingCartViewModel : BindableBase, IShoppingCartViewModel
    {
        public IView View { get; set; }
        public IShoppingCart ShoppingCart { get; set; }
        public CustomerLoyaltyType CustomerLoyalty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        IRegionManager _regionManager { get; set; }
        IUnityContainer _container { get; set; }
        IEventAggregator _eventAggregator { get; set; }

        private ObservableCollection<ProductEntity> productsInDB { get; set; }
        public DelegateCommand<string> IncreaseItemCommand { get; set; }
        public DelegateCommand<string> DecreaseItemCommand { get; set; }
        public DelegateCommand AddItemCommand { get; set; }
        public DelegateCommand PurchaseCartCommand { get; set; }
        public CustomerEntity OwnerOfCart { get; set; }

        public ShoppingCartViewModel(IShoppingCartView view, int ShoppingCartId, IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            View = view;
            View.ViewModel = this;
            _regionManager = regionManager;
            _container = container;
            _eventAggregator = eventAggregator;
            ShoppingCart = new ShoppingCartModel(ShoppingCartId);
            _eventAggregator.GetEvent<RecieveUserDataEvent>().Subscribe(SuccesfullLogin);

            IncreaseItemCommand = new DelegateCommand<string>(IncreaseQuantityOfItem);
            DecreaseItemCommand = new DelegateCommand<string>(DecreaseQuantityOfItem);
            AddItemCommand = new DelegateCommand(AddToShoppingCart);
            PurchaseCartCommand = new DelegateCommand(PurchaseItemsInCart);

            //Get all products to simulate SKU access
            ProductService service = new ProductService();
            productsInDB = service.GetAllProducts();
           
        }

        public void AddToShoppingCart()
        {

            try
            {
                var availableProduct = productsInDB.First();
                if (availableProduct != null)
                {
                    ShoppingCart.AddItemToCart(availableProduct);
                    productsInDB.Remove(availableProduct);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("No More Items to add");
            }

        }

        public void IncreaseQuantityOfItem(string itemName)
        {
            var availableProduct = productsInDB.FirstOrDefault(p => p.Name == itemName);
            if (availableProduct != null)
            {
                ShoppingCart.AddItemToCart(availableProduct);
                productsInDB.Remove(availableProduct);
            }
        }

        public void RemoveItemFromCart(string itemName)
        {
            // TODO: To clear all type of an item from list
            throw new NotImplementedException();
        }

        public void DecreaseQuantityOfItem(string itemName)
        {
            var removedItem = ShoppingCart.RemoveItemFromCart(itemName);
            productsInDB.Add(removedItem);
        }

        public string CartContentToString()
        {
            var currentCartItems = ShoppingCart.CartItems;
            StringBuilder sb = new StringBuilder();
            foreach (var item in currentCartItems)
            {
                sb.Append(item.NameOfProduct + "x" + item.NumberOfProducts + " = £" + item.TotalPrice + ",");
            }

            switch (OwnerOfCart.LoyaltyStatus)
            {
                case CustomerLoyaltyType.Standard:
                    sb.Append("Total= £" + ShoppingCart.TotalCost());
                    break;
                case CustomerLoyaltyType.Silver:
                    var totalWithDiscount = 0.98 * ShoppingCart.TotalCost();
                    sb.Append("Total(Includes Silver discount)= £" + totalWithDiscount);
                    break;
                case CustomerLoyaltyType.Gold:
                    var totalWithGoldDiscount = 0.95 * ShoppingCart.TotalCost();
                    sb.Append("Total(Includes Gold discount)= £" + totalWithGoldDiscount);
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }

        public void PurchaseItemsInCart()
        {
            if (ShoppingCart.CartItems.Count < 1)
                throw new Exception("There needs to be items in the cart to purchase them");
            float totalWithDiscount = 0;
            float userBalance = (float)OwnerOfCart.Balance;
            switch (OwnerOfCart.LoyaltyStatus)
            {
                case CustomerLoyaltyType.Standard:
                    totalWithDiscount =  ShoppingCart.TotalCost();
                    break;
                case CustomerLoyaltyType.Silver:
                    totalWithDiscount = (float)(0.98 * ShoppingCart.TotalCost());
                    break;
                case CustomerLoyaltyType.Gold:
                    totalWithDiscount = (float)0.95 * ShoppingCart.TotalCost();
                    break;
                default:
                    break;
            }

            if (totalWithDiscount > userBalance)
            {
                throw new Exception("Insufficient Funds");
            }

            ShopOrderService shopOrderService = new ShopOrderService();
            ProductService productService = new ProductService();

            //Create new Order
            ShopOrderEntity shopOrderEntity = new ShopOrderEntity()
            {
                Id = new Random().Next(1,10000),
                CustomerIde = OwnerOfCart.Id,
                PurchaseDate = DateTime.Now,
                TotalCost = totalWithDiscount
            };

            var newOrderId = shopOrderEntity.Id;
            shopOrderService.CreateOrder(shopOrderEntity);

            //Update products in order with new order
            var currentCartItems = ShoppingCart.CartItems;
            foreach (var item in currentCartItems)
            {
                foreach (var productItem in item.Products)
                {
                    productService.UpdateProductWithOrder(productItem.Id, newOrderId);
                }
            }

            //Update User Balance
            CustomerService customerService = new CustomerService();
            customerService.UpdateBalance(OwnerOfCart.Name, OwnerOfCart.Email, totalWithDiscount);
            var newTotalSpend = OwnerOfCart.Spend + totalWithDiscount;
            CustomerLoyaltyType newLoyaltyStatus;
            if (newTotalSpend > 1500)
            {
                newLoyaltyStatus = CustomerLoyaltyType.Gold;
            }
            else if (newTotalSpend > 500)
            {
                newLoyaltyStatus = CustomerLoyaltyType.Silver;
            }
            else
            {
                newLoyaltyStatus = CustomerLoyaltyType.Standard;
            }

            OwnerOfCart.Balance -= totalWithDiscount;
            OwnerOfCart.LoyaltyStatus = newLoyaltyStatus;
            OwnerOfCart.Spend = newTotalSpend;

            //Shop Order View
            IRegion region = _regionManager.Regions[RegionNames.MainRegion];
            var vm = _container.Resolve<IOrderRetrievalViewModel>();
            _eventAggregator.GetEvent<RecieveUserDataEvent>().Publish(OwnerOfCart);
            region.Remove(View);
            region.Add(vm.View);
            region.Activate(vm.View);

        }

        public void SuccesfullLogin(CustomerEntity entity)
        {
            OwnerOfCart = entity;
        }

        //TODO: Disable button if no items in cart using raisecanexecute
        public bool CanPurchaseItem()
        {
            if (ShoppingCart.CartItems.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
