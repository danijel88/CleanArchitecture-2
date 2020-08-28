using System;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IWriteService<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Get(Guid id);
    }
}