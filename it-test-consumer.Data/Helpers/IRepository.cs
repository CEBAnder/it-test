using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace it_test_consumer.Data.Helpers
{
    public interface IRepository
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> expression);

            Task<TEntity> FindOne(Expression<Func<TEntity, bool>> expression);

            Task Add(TEntity entity);

            Task Update(TEntity entity);

            IQueryable<TEntity> Skip(int elemsToSkip);

            IQueryable<TEntity> Take(int elemsToTake);

            IIncludableQueryable<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> propertyToInclude);

            IOrderedEnumerable<TEntity> OrderBy<TKey>(Func<TEntity, TKey> keySelector);
        }
    }
}
