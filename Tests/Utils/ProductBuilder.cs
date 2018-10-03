using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataProvider;

namespace Tests.Utils
{
    public class ProductBuilder
    {
        public ProductBuilder(Product product = null)
        {
            Product = product ?? new Product();
        }

        public Product Product { get; set; }

        public ProductBuilder WithName(string name)
        {
            Product.ProductName = name;
            return this;
        }

        public ProductBuilder WithId(int id)
        {
            Product.ProductID = id;
            return this;
        }

        public ProductBuilder WithDiscontinued(bool discounted)
        {
            Product.Discontinued = discounted;
            return this;
        }

        public ProductBuilder WithCategory(Category category)
        {
            Product.Category = category;
            return this;
        }

        public ProductBuilder WithSupplier(Supplier supplier)
        {
            Product.Supplier = supplier;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            Product.UnitPrice = price;
            return this;
        }

        public Product Build()
        {
            return Product;
        }
    }
}
