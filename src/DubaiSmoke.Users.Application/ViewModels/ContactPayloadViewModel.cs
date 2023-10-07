using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Application.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ContactPayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public long userId { get; set; }
        [Required(ErrorMessage = "*")]
        public long typeId { get; set; }
        [Required(ErrorMessage = "*")]
        public string value { get; set; }
    }
}
