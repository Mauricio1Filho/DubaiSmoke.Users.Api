using System.ComponentModel.DataAnnotations;

namespace DubaiSmoke.Users.Application.ViewModels
{
    public class UserPayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
        public string birthDay { get; set; }
        [Required(ErrorMessage = "*")]
        public string login { get; set; }
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
    }
}
