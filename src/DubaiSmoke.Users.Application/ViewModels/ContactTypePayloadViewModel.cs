using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ContactTypePayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
    }
}
