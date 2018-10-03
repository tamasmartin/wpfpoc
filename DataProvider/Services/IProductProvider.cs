using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Services
{
    public interface IProductProvider
    {
        IQueryable<Product> GetAllProducts();

        IQueryable<Product> GetAllProductsByName(string name);
    }
}
