using System.ComponentModel.DataAnnotations;

namespace DubaiSmoke.Users.Application.ViewModels
{
    public class AddressPayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public string addressName { get; set; }
        [Required(ErrorMessage = "*")]
        public int addressNumber { get; set; }
        public string addressComplement { get; set; }
        [Required(ErrorMessage = "*")]
        public string postalCode { get; set; }
    }
}
