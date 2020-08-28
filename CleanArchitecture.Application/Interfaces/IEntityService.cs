using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IEntityService<TEntity>
    {
        IQueryable<TEntity> Entities { get; }

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        bool Delete(object id);

        bool Delete(TEntity entity);

        Task<bool> DeleteAsync(params object[] keyValues);

        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);

        bool DeleteRange(ICollection<TEntity> entities);

        TEntity Find(params object[] keyValues);

        Task<TEntity> FindAsync(params object[] keyValues);

        Task<TEntity> FindAsync(Guid id, List<Expression<Func<TEntity, object>>> includes);

        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);

        Task<TEntity> FirstOrDefaultAsync(IQueryable<TEntity> query);

        bool Insert(TEntity entity);

        bool InsertGraphRange(ICollection<TEntity> entities);

        bool InsertOrUpdateGraph(TEntity entity);

        bool InsertRange(ICollection<TEntity> entities);

        IQueryable<TEntity> Queryable();

        Task<IList<TResult>> SelectAsync<TResult>(IQueryable<TEntity> query,
            Expression<Func<TEntity, TResult>> selector);

        Task<IList<TEntity>> SelectListAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null);

        Task<IList<TEntity>> SelectListAsync(IQueryable<TEntity> query, int? page = null, int? pageSize = null);

        IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        bool Update(TEntity entity);
    }
}