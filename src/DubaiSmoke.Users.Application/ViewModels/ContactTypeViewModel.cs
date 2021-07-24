using System;
using System.ComponentModel.DataAnnotations;

namespace DubaiSmoke.Users.Application.ViewModels
{
    public class ContactTypeViewModel
    {
        [Required(ErrorMessage = "*")]
        public long id { get; set; }
        [Required(ErrorMessage = "*")]
        public string name { get; set; }
    }
}
