using System;
using System.Linq;
using System.Reflection;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Validation.FluentValidation
{
    /// <summary>
    ///     https://github.com/FluentValidation/FluentValidation/issues/55
    /// </summary>
    public class ValidationService : IValidationService
    {
        public IValidationResult Validate(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Type validationType = typeof(AbstractValidator<>);
            Type entityType = entity.GetType();
            Type entityValidatorType = validationType.MakeGenericType(entityType);

            Type validatorType = FindValidatorType(Assembly.GetExecutingAssembly(), entityValidatorType);

            IValidator validatorInstance = (IValidator) Activator.CreateInstance(validatorType);

            IValidationContext context = new ValidationContext<object>(entity);
            ValidationResult result = validatorInstance.Validate(context);


            return new BaseValidationResult(result);
        }

        private static Type FindValidatorType(Assembly assembly, Type type)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            if (type == null) throw new ArgumentNullException(nameof(type));

            return assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(type));
        }
    }
}