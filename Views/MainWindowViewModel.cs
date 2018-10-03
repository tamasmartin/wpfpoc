using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using DataProvider;
using DataProvider.Annotations;
using DataProvider.Services;

namespace WpfApplicationPoc.Views
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IProductProvider _productProvider;
        public CollectionViewSource Collection { get; private set; }
        private Product _selectedProduct;
        private List<Product> _products;
        private string _name;

        public MainWindowViewModel(IProductProvider provider)
        {
            _productProvider = provider;
            Collection = new CollectionViewSource
            {
                Source = new ObservableCollection<Product>(_productProvider.GetAllProducts())
            };
        }

        public void Refresh(string name)
        {
            _products = _productProvider.GetAllProductsByName(name).ToList();
            Collection.Source = new ObservableCollection<Product>(_products);
        }

        public Product SelectedItem
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public string NameSearch
        {
            get => _name;
            set
            {
                _name = value;
                Refresh(_name);
                OnPropertyChanged(nameof(NameSearch));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
