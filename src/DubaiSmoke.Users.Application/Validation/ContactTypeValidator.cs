using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;

namespace DubaiSmoke.Users.Application.Validator
{
    public class ContactTypeValidator : AbstractValidator<ContactTypePayloadViewModel>
    {
        public ContactTypeValidator()
        {
            RuleFor(x => x.name).NotNull().NotEmpty().WithMessage("O Nome é obrigatório");
        }
    }
}
