using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Services
{
    public abstract class BaseService<TEntity> : IWriteService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IBaseServiceProvider<TEntity> _baseServiceProvider;

        protected BaseService(IBaseServiceProvider<TEntity> baseServiceProvider)
        {
            _baseServiceProvider = baseServiceProvider;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            return await _baseServiceProvider.Create(entity);
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await _baseServiceProvider.Get(id);
        }


        protected string CreateLogMessage(string message, [CallerMemberName] string callerName = "")
        {
            return $"{callerName} - {message}";
        }
    }
}