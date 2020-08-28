using CleanArchitecture.Application.CrossCuttingConcerns.Logging;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Domain.Common;
using FluentValidation;

namespace CleanArchitecture.Application.Interfaces
{
    public interface IBaseServiceProvider<TEntity> : IWriteService<TEntity> where TEntity : class, IEntity, new()
    {
        ILogService LogService { get; }
        IEntityService<TEntity> EntityService { get; }
        IValidationService ValidationService { get; }
    }
}