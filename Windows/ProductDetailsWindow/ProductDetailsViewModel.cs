using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DataProvider;
using DataProvider.Annotations;
using DataProvider.Repository;

namespace WpfApplicationPoc.Windows.ProductDetailsWindow
{
    public class ProductDetailsViewModel : INotifyPropertyChanged
    {
        public Action CloseAction { get; set; }

        public ICommand SaveCommand { get; private set; }

        private ProductRepository _repo;

        public Product Product { get; private set; }

        public ProductDetailsViewModel(ProductRepository repo)
        {
            _repo = repo;
            SaveCommand = new SaveProductDetailsCommand(_repo, this);
        }

        public void SetProduct(int id)
        {
            var prod = _repo.GetProductById(id);
            Product = prod;
        }

        public void Close()
        {
            CloseAction();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
