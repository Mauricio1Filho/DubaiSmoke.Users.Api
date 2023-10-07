using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("contacts_type")]
    public class ContactTypeEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
