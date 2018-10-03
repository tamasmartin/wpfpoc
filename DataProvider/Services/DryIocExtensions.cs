using DataProvider.Repository;
using DryIoc;

namespace DataProvider.Services
{
    public static class DryIocExtensions
    {
        public static void AddServiceLayer(this IContainer c)
        {
            c.Register<NorthWindContext>(
                Reuse.Singleton,
                Made.Of(() => new NorthWindContext()));
            c.Register<IProductProvider, ProductProvider>();
            c.Register<ProductRepository>();
        }
    }
}
