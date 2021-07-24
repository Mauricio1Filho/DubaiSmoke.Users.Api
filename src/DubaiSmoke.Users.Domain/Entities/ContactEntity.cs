using DubaiSmoke.Users.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiSmoke.Users.Domain.Entities
{
    [Table("contacts")]
    public class ContactEntity : BaseEntity
    {
        public long UserId { get; set; }
        public long TypeId { get; set; }
        public string Value { get; set; }
        public ContactTypeEntity ContactType { get; set; }
        public UserEntity User { get; set; }
    }
}
