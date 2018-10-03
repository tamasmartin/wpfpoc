using System;
using DataProvider;
using DryIoc;
using WpfApplicationPoc.Windows.Abstract;

namespace WpfApplicationPoc.Windows.ProductDetailsWindow
{
    /// <inheritdoc />
    public partial class ProductDetails : WindowBase
    {
        private int id;
        private Product _product;
        private MainWindow MainWindow;

        public ProductDetails()
        {
            Logger.Information("ProductDetails is created");
            InitializeComponent();
        }

        public void LoadProduct(MainWindow mainWindow, int id)
        {
            this.id = id;
            MainWindow = mainWindow;
            var productDetailsViewModel = App.Container.Resolve<ProductDetailsViewModel>();
            productDetailsViewModel.SetProduct(id);
            if (productDetailsViewModel.CloseAction == null)
            {
                productDetailsViewModel.CloseAction = new Action(this.Close);
            }
            DataContext = productDetailsViewModel;
            Logger.Information("ProductDetails form opened");
        }

        protected override string GetWindowTitle()
        {
            return "Product Details";
        }
    }
}
