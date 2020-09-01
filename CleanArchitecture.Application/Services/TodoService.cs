using System.Threading.Tasks;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services
{
    public class TodoService : BaseService<Todo>, ITodoService
    {
        private readonly IBaseServiceProvider<Todo> _baseServiceProvider;

        public TodoService(IBaseServiceProvider<Todo> baseServiceProvider) : base(baseServiceProvider)
        {
            _baseServiceProvider = baseServiceProvider;
        }

        public async Task<TodoResponseModel> Create(TodoCreateRequestModel request)
        {
            IValidationResult validateResult = await Validate(request);

            if (!validateResult.IsValid)
            {
                _baseServiceProvider.LogService.Error("Invalid request");
                throw new InvalidRequestException();
            }

            Todo result = await Create(request.ToEntity());

            // TODO AutoMapping
            return result?.ToDetails();
        }

        public async Task<IValidationResult> Validate(TodoCreateRequestModel request)
        {
            return _baseServiceProvider.ValidationService.Validate(request);
        }
    }
}