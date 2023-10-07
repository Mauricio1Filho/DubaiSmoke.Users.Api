using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.Validation
{
    [ExcludeFromCodeCoverage]
    public class ContactTypeValidator : AbstractValidator<ContactTypePayloadViewModel>
    {
        public ContactTypeValidator()
        {
            RuleFor(x => x.name).NotNull().NotEmpty().WithMessage("O Nome é obrigatório");
        }
    }
}
