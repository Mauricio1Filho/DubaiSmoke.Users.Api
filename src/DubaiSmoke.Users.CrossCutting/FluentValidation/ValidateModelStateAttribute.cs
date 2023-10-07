using DubaiSmoke.Users.CrossCutting.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.FluentValidation
{
    [ExcludeFromCodeCoverage]
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new BadRequestResponse();
                foreach (KeyValuePair<string, ModelStateEntry> modelStateDD in context.ModelState)
                {
                    string key = modelStateDD.Key;
                    var modelState = modelStateDD.Value;
                    var newError = new ValidationError()
                    {
                        field = key
                    };
                    foreach (ModelError error in modelState.Errors)
                    {
                        if (!error.ErrorMessage.Equals("*"))
                            newError.messages.Add(error.ErrorMessage);
                    }
                    response._errors.Add(newError);
                }

                context.Result = new JsonResult(response)
                {
                    StatusCode = 400
                };
            }
        }
    }
}
