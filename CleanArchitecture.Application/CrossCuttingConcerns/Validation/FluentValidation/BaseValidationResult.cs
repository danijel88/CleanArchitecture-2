using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    public class BaseValidationResult : IValidationResult
    {
        private readonly ValidationResult _fluentValidationResult;

        public BaseValidationResult(ValidationResult _fluentValidationResult)
        {
            this._fluentValidationResult = _fluentValidationResult;
        }

        public IList<IValidationError> Errors
        {
            get
            {
                IList<IValidationError> errors = new List<IValidationError>();
                if (!_fluentValidationResult.Errors.Any())
                {
                    return errors;
                }

                foreach (ValidationFailure error in _fluentValidationResult.Errors)
                {
                    errors.Add(new ValidationError(error));
                }

                return errors;
            }
        }


        public bool IsValid => _fluentValidationResult.IsValid;
    }
}