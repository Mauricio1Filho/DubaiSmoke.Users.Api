using System;
using System.ComponentModel.DataAnnotations;

namespace DubaiSmoke.Users.Application.ViewModels
{
    public class ContactTypePayloadViewModel
    {
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
    }
}
