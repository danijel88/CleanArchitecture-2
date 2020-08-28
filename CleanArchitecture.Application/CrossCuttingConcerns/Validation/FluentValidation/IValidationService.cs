using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    public interface IValidationService
    {
        IValidationResult Validate(object entity);
    }
}