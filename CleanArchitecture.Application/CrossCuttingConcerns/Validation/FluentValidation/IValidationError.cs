namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    public interface IValidationError
    {
        string ErrorCode { get; set; }

        string ErrorMessage { get; }
    }
}