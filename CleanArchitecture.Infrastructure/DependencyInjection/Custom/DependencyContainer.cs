using CleanArchitecture.Application.CrossCuttingConcerns.Logging;
using CleanArchitecture.Application.CrossCuttingConcerns.Logging.Log4Net;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.DependencyInjection.Custom
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ILogService, Log4NetLogger>();
            services.AddScoped<IValidationService, ValidationService>();

            services.AddScoped(typeof(IBaseServiceProvider<>), typeof(BaseServiceProvider<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
        }
    }
}