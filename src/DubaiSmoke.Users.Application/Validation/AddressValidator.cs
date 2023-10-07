using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.Validation
{
    [ExcludeFromCodeCoverage]
    public class AddressValidator : AbstractValidator<AddressPayloadViewModel>
    {
        public AddressValidator()
        {
            RuleFor(x => x.addressName).NotNull().NotEmpty().WithMessage("O endereço é obrigatório");
            RuleFor(x => x.addressName).MaximumLength(50).WithMessage("O endereço tem quer ter no maximo 50 caracteres");
            RuleFor(x => x.addressNumber).NotNull().NotEmpty().WithMessage("O numero do endereco é obrigatório");
            RuleFor(x => x.addressComplement).MaximumLength(50).WithMessage("O complemento tem que ter no maximo 50 caracteres");
            RuleFor(x => x.postalCode).NotNull().NotEmpty();
            RuleFor(x => x.postalCode).Length(8);
        }
    }
}
