using System.Collections.Generic;
using FluentValidation.Results;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    public interface IValidationResult
    {
        bool IsValid { get; }
        IList<IValidationError> Errors { get; }
    }
}