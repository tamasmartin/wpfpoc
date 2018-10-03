using System.ServiceModel;
using DataProvider;
using DataProvider.Repository;

namespace WcfServiceLibrary
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class ProductProviderWcfWcf : IProductProviderWcf
    {

        public ProductDto GetProduct(int productId)
        {
            using (var dbContext = new NorthWindContext())
            {
                var pr = new ProductRepository(dbContext);
                var product = pr.GetProductById(productId);
                return new ProductDto()
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice ?? 0,
                    Discontinued = product.Discontinued,
                    QuantityPerUnit = product.QuantityPerUnit
                };
            }
        }

    }
}
