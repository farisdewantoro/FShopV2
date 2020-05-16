using FShopV2.Base.Types;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FShopV2.Base.MongoDB
{
    public interface IMongoRepository<TEntity> where TEntity : IIdentifiable
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<PagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
             TQuery query) where TQuery : PagedQueryBase;
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetAsync(Guid id);
        Task UpdateAsync(TEntity entity);
    }
}