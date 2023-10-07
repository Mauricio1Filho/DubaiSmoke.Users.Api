using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Domain.Entities
{
    [ExcludeFromCodeCoverage]
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
