using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class UserViewModel
    {
        public long id { get; set; }
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
        public string birthDay { get; set; }
    }
}
