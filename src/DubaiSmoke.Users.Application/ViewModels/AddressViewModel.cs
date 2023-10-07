using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AddressViewModel
    {
        [Required(ErrorMessage = "*")]
        public long userId { get; set; }
        [Required(ErrorMessage = "*")]
        public string addressName { get; set; }
        [Required(ErrorMessage = "*")]
        public int addressNumber { get; set; }
        public string addressComplement { get; set; }
        [Required(ErrorMessage = "*")]
        public string postalCode { get; set; }
        public UserViewModel user { get; set; }
    }
}
