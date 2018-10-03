using System.Linq;
using System.Data.Entity;

namespace DataProvider.Services
{
    public class ProductProvider : IProductProvider
    {
        private readonly NorthWindContext _northWindContext;

        public ProductProvider(NorthWindContext context)
        {
            _northWindContext = context;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _northWindContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Supplier);
        }

        public IQueryable<Product> GetAllProductsByName(string name)
        {
            return _northWindContext.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.ProductName.Contains(name));
        }

        public IQueryable<Product> GetDiscountedProducts()
        {
            return _northWindContext.Products
                    .Where(p => p.Discontinued);
        }

        public IQueryable<Product> GetCheaperProducts(decimal limit)
        {
            return _northWindContext.Products
                .Where(p => (p.UnitPrice != null) && ((decimal)p.UnitPrice) > limit);
        }
    }
}
