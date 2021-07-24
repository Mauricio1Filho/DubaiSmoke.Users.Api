using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;

namespace DubaiSmoke.Users.Application.Validator
{
    public class AddressValidator : AbstractValidator<AddressViewModel>
    {
        public AddressValidator()
        {
            RuleFor(x => x.postalCode).NotNull().NotEmpty();
            RuleFor(x => x.postalCode).Length(8);
        }
    }
}
