using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class LoginPayloadViewModel
    {
        public string email { get; set;}
        public string password { get; set;}
    }
}
