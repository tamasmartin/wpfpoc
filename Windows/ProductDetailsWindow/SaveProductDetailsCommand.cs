using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataProvider;
using DataProvider.Repository;
using WpfApplicationPoc.Views;

namespace WpfApplicationPoc.Windows.ProductDetailsWindow
{
    public class SaveProductDetailsCommand :ICommand
    {
        private Product _product;
        private ProductRepository _repository;
        private ProductDetailsViewModel _model;

        public SaveProductDetailsCommand(ProductRepository repository, ProductDetailsViewModel model)
        {
            _repository = repository;
            _model = model;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _repository.AddOrUpdateProduct((Product)parameter);
            _model.CloseAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
