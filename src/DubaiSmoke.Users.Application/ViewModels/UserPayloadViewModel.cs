using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class UserPayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
        [Required(ErrorMessage = "*")]
        public string birthDay { get; set; }
        [Required(ErrorMessage = "*")]
        public string login { get; set; }
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
    }
}
