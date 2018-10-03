using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataProvider;
using Moq;

namespace Tests.Utils
{
    public sealed class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : class 
    {
        public MockDbSet(IList<TEntity> dataSource = null)
        {
            var data = dataSource ?? new List<TEntity>();
            var queryable = data.AsQueryable();

            this.As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(queryable.Provider);
            this.As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(queryable.Expression);
            this.As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(queryable.ElementType);
            As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        }
    }
}
