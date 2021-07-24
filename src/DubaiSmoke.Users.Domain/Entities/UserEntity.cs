using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiSmoke.Users.Domain.Entities
{
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
