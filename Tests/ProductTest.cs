using System;
using System.Collections.Generic;
using System.Linq;
using DataProvider;
using DataProvider.Services;
using FluentAssertions;
using Moq;
using Tests.Utils;
using Xunit;

namespace Tests
{

    public class ProductTest
    {
        [Fact]
        public void TestMethod1()
        {
            var dataSource = GetTestProducts(10);
            var enumerable = dataSource as Product[] ?? dataSource.ToArray();
            enumerable.ToList().ForEach(p =>
            {
                Console.WriteLine(p.UnitPrice);
            });

            var productMockSet = new MockDbSet<Product>(enumerable.ToList());
            productMockSet.Setup(prod => prod.Include(nameof(Category))).Returns(productMockSet.Object);
            productMockSet.Setup(prod => prod.Include(nameof(Supplier))).Returns(productMockSet.Object);

            var mockContext = new Mock<NorthWindContext>();
            mockContext.Setup(c => c.Products).Returns(productMockSet.Object);

            var provider = new ProductProvider(mockContext.Object);
            var products = provider.GetAllProducts();

            Console.WriteLine(products);
            products.Count().Should().Be(10);

            var discounted = provider.GetDiscountedProducts();
            discounted.Count().Should().Be(0);

            var cheap = provider.GetCheaperProducts(10m).ToArray<Product>();

            cheap.Should().NotBeNull();
            var cnt = cheap.Length;
            cnt.Should().Be(10);
        }

        private static IEnumerable<Product> GetTestProducts(int n = 1)
        {
            var supplier = new Supplier()
            {
                SupplierID = 1,
                CompanyName = "Supplier",
                City = "Szeged",
                Address = "Kígyó utca 3"
            };

            var category = new Category()
            {
                CategoryID = 1,
                CategoryName = "Test Category"
            };

            var defaultProduct = new Product()
            {
                ProductName = "Test product",
                Category = category,
                Discontinued = false,
                ProductID = 1,
                QuantityPerUnit = "6 pack of beer",
                UnitPrice = new decimal(12.33d),
                Supplier = supplier,
            };

            for (var i = 0; i < n; i++)
            {
                yield return (new ProductBuilder(defaultProduct)
                    .WithId(i + 1)
                    .WithDiscontinued(false)
                    .WithPrice(i + 6m)
                    .Build());
            }


        }
    }
}
