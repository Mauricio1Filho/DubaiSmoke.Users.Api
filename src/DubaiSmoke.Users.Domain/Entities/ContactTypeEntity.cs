using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiSmoke.Users.Domain.Entities
{
    [Table("contacts_type")]
    public class ContactTypeEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
