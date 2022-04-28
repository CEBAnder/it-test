using it_test_consumer.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static it_test_consumer.Data.Helpers.IRepository;

namespace it_test_consumer.Data.Helpers
{
    public abstract class MsSQLRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ItTestDbContext _dbContext { get; set; }

        protected MsSQLRepository(ItTestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _dbContext.Set<TEntity>().Where(expression).ToListAsync();

            return result;
        }

        public async Task<TEntity> FindOne(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (result == null)
                throw new EntityNotFoundException<TEntity>();

            return result;
        }

        public async Task Add(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> Skip(int elemsToSkip)
        {
            return _dbContext.Set<TEntity>().Skip(elemsToSkip);
        }

        public IQueryable<TEntity> Take(int elemsToTake)
        {
            return _dbContext.Set<TEntity>().Take(elemsToTake);
        }

        public IIncludableQueryable<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> propertyToInclude)
        {
            return _dbContext.Set<TEntity>().Include(propertyToInclude);
        }

        public IOrderedEnumerable<TEntity> OrderBy<TKey>(Func<TEntity, TKey> keySelector)
        {
            return _dbContext.Set<TEntity>().OrderBy(keySelector);
        }
    }
}
