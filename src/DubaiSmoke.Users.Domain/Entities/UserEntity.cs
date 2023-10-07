using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("users")]
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
