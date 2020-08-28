using System.Threading.Tasks;
using CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation;
using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Interfaces
{
    public interface ITodoService
    {
        Task<TodoResponseModel> Create(TodoCreateRequestModel request);
        Task<IValidationResult> Validate(TodoCreateRequestModel request);
    }
}