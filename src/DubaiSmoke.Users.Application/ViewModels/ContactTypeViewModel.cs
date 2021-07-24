using System;
using System.ComponentModel.DataAnnotations;

namespace DubaiSmoke.Users.Application.ViewModels
{
    public class ContactTypeViewModel
    {
        [Required]
        public long id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
