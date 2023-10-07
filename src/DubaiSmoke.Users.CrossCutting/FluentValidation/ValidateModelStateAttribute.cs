using ErrorHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using static ErrorHandler.Models.ErrorHandlerNotification.ClientError;

namespace DubaiSmoke.Users.CrossCutting.FluentValidation
{
    [ExcludeFromCodeCoverage]
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        ErrorHandlerNotification _error = new ErrorHandlerNotification();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                foreach (KeyValuePair<string, ModelStateEntry> modelStateDD in context.ModelState)
                {
                    string field = modelStateDD.Key;
                    var modelState = modelStateDD.Value;

                    foreach (ModelError error in modelState.Errors)
                    {
                        if (!error.ErrorMessage.Equals("*"))
                            _error.Handle(new ErrorDetail(error.ErrorMessage, string.Empty, field, HttpStatusCode.BadRequest));
                    }
                }

                context.Result = new JsonResult(_error.GetNotifications())
                {
                    StatusCode = 400
                };
            }
        }
    }
}
