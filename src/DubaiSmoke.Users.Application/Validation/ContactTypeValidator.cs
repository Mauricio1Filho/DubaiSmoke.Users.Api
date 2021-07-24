using DubaiSmoke.Users.Application.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DubaiSmoke.Users.Application.Validator
{
    public class ContactTypeValidator : AbstractValidator<ContactTypeViewModel>
    {
        public ContactTypeValidator()
        {
           
        }
    }
}
