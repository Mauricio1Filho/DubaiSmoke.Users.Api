using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;

namespace DubaiSmoke.Users.Application.Validator
{
    public class ContactValidator : AbstractValidator<ContactPayloadViewModel>
    {
        public ContactValidator()
        {
            RuleFor(x => x.userId).NotNull().NotEmpty().WithMessage("O userId é obrigatório");
            RuleFor(x => x.typeId).NotNull().NotEmpty().WithMessage("O typeId é obrigatório");
            RuleFor(x => x.value).NotNull().NotEmpty().WithMessage("O valor é obrigatório");
            
        }
    }
}
