using FluentValidation.Results;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    public class ValidationError : IValidationError
    {
        public ValidationError()
        {
        }

        public ValidationError(ValidationFailure failure)
        {
            ErrorMessage = failure.ErrorMessage;
            ErrorCode = failure.ErrorCode;
        }

        public string ErrorCode { get; set; }
        public string ErrorMessage { get; }
    }
}