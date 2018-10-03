using DataProvider.Annotations;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataProvider.Repository
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public int? ProductId { get; set; }

        public string ProductName { get; set; }

        public string Category { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public ProductViewModel(Product p)
        {
            ProductId = p.ProductID;
            ProductName = p.ProductName;
            Category = p.Category.CategoryName;
            UnitPrice = p.UnitPrice;
            UnitsInStock = p.UnitsInStock;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
