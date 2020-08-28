using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Interfaces;

namespace CleanArchitecture.Application.Services
{
    public class EntityService<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IBaseRepository<TEntity> _repository;

        public EntityService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.AnyAsync(predicate);
        }

        public bool Delete(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            TEntity entity = _repository.Find(id);

            if (entity != null)
                return Delete(entity);
            return false;
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            _repository.Delete(entity);
            return true;
        }

        public async Task<bool> DeleteAsync(params object[] keyValues)
        {
            return await DeleteAsync(CancellationToken.None, keyValues);
        }

        public async Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            if (keyValues == null)
                throw new ArgumentNullException(nameof(keyValues));

            TEntity entity = await _repository.FindAsync(cancellationToken, keyValues);

            if (entity != null)
            {
                Delete(entity);
                return true;
            }

            return false;
        }

        public bool DeleteRange(ICollection<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _repository.DeleteRange(entities);

            return true;
        }

        public IQueryable<TEntity> Entities => Queryable();


        public TEntity Find(params object[] keyValues)
        {
            if (keyValues == null) throw new ArgumentNullException(nameof(keyValues));

            TEntity entity = _repository.Find(keyValues);

            return entity;
        }

        public async Task<TEntity> FindAsync(params object[] keyValues)
        {
            if (keyValues == null)
                throw new ArgumentNullException(nameof(keyValues));

            TEntity entity = await _repository.FindAsync(keyValues);

            return entity;
        }

        public async Task<TEntity> FindAsync(Guid id, List<Expression<Func<TEntity, object>>> includes)
        {
            TEntity entity = await _repository.FindAsync(id, includes);
            return entity;
        }

        public async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            if (keyValues == null)
                throw new ArgumentNullException(nameof(keyValues));

            TEntity entity = await _repository.FindAsync(cancellationToken, keyValues);

            return entity;
        }

        public async Task<TEntity> FirstOrDefaultAsync(IQueryable<TEntity> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await _repository.FirstOrDefaultAsync(query);
        }

        public bool Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Insert(entity);
            return true;
        }

        public bool InsertGraphRange(ICollection<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _repository.InsertGraphRange(entities);

            return true;
        }

        public bool InsertOrUpdateGraph(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _repository.UpsertGraph(entity);

            return true;
        }

        public bool InsertRange(ICollection<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));

            _repository.InsertRange(entities);

            return true;
        }

        public IQueryable<TEntity> Queryable()
        {
            return _repository.Queryable();
        }

        public async Task<IList<TResult>> SelectAsync<TResult>(IQueryable<TEntity> query,
            Expression<Func<TEntity, TResult>> selector)
        {
            return await _repository.SelectAsync(query, selector);
        }

        public async Task<IList<TEntity>> SelectListAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null, int? page = null,
            int? pageSize = null)
        {
            return await _repository.SelectListAsync(filter, orderBy, includes, page, pageSize);
        }

        public async Task<IList<TEntity>> SelectListAsync(IQueryable<TEntity> query, int? page = null,
            int? pageSize = null)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return await _repository.SelectListAsync(query, page, pageSize);
        }

        public IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        {
            if (string.IsNullOrEmpty(query)) throw new ArgumentNullException(nameof(query));

            return _repository.SelectQuery(query, parameters);
        }

        public bool Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            _repository.Update(entity);

            return true;
        }
    }
}