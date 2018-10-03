using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataProvider;
using DryIoc;
using WpfApplicationPoc.Views;
using WpfApplicationPoc.Windows;
using WpfApplicationPoc.Windows.Abstract;
using WpfApplicationPoc.Windows.ProductDetailsWindow;

namespace WpfApplicationPoc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        protected MainWindowViewModel MainWindowViewModel;

        public MainWindow(MainWindowViewModel model)
        {
            Logger.Debug("MainWindow is created");
            InitializeComponent();
            MainWindowViewModel = model;
            DataContext = MainWindowViewModel;
        }

        private void OKbutton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var pd = App.Container.Resolve<ProductDetails>();
            pd.LoadProduct(this, MainWindowViewModel.SelectedItem.ProductID);
            pd.Show();
        }

        public void ReloadProducts()
        {
            
        }

        protected override string GetWindowTitle()
        {
            return "Products";
        }
    }
}