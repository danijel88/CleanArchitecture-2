using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.CrossCuttingConcerns.Logging;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Common;
using FluentValidation;

namespace CleanArchitecture.Application.Services
{
    public class BaseServiceProvider<TEntity> : IBaseServiceProvider<TEntity>
        where TEntity : class, IEntity, new()
    {
        public IEntityService<TEntity> EntityService { get; }
        public IValidationService ValidationService { get; }
        public ILogService LogService { get; }

        public BaseServiceProvider(ILogService logService, IEntityService<TEntity> entityService, IValidationService validationService)
        {
            LogService = logService;
            EntityService = entityService;
            ValidationService = validationService;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            bool inserted = EntityService.Insert(entity);
            if (!inserted)
            {
                LogService.Error("Failed inserting entity");
                throw new Exception("Failed inserting entity");
            }

            return await Get(entity.Id);
        }

        
        public async Task<TEntity> Get(Guid id)
        {
            TEntity entity = await EntityService.FindAsync(id);
            return entity;
        }
    }
}