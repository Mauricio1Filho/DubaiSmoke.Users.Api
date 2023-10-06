using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;

namespace DubaiSmoke.Users.Application.Validation
{
    public class UserValidator : AbstractValidator<UserPayloadViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.login).NotNull().NotEmpty().WithMessage("O Émail é Obrigatório");
            RuleFor(x => x.login).EmailAddress().WithMessage("Formato de Email Invalido");
            RuleFor(x => x.name).NotEmpty().WithMessage("O Nome é Obrigatório");
            RuleFor(x => x.password).NotEmpty().WithMessage("A Senha é Obrigatória");
            RuleFor(x => x.password).MinimumLength(10).WithMessage("A Senha tem q tem no minimo 10 caracteres ");
        }
    }
}
