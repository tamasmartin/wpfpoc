using DataProvider.Exceptions;
using System.Data.Entity;
using System.Linq;

namespace DataProvider.Repository
{
    public class ProductRepository
    {
        private NorthWindContext _context;

        public ProductRepository(NorthWindContext context)
        {
            this._context = context ?? throw new InvalidParameterException("NorthWindContext was null");
        }

        public Product GetProductById(int id)
        {
            return _context.Products.First(p => p.ProductID == id);
        }

        public void AddOrUpdateProduct(Product prod)
        {
            _context.Entry(prod).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
