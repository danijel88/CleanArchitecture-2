using CleanArchitecture.Application.Models;
using FluentValidation;

namespace CleanArchitecture.Application.ValidationRules.FluentValidation
{
    public class TodoCreateRequestValidator : AbstractValidator<TodoCreateRequestModel>
    {
        public TodoCreateRequestValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255);
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Title can not be empty")
                .NotNull()
                .WithMessage("Title can not be null")
                .MaximumLength(20)
                .WithMessage("Title can contain only 20 characters");
        }
    }
}