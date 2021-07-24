using System.ComponentModel.DataAnnotations.Schema;

namespace DubaiSmoke.Users.Domain.Entities
{
    [Table ("address")]
    public class AddressEntity : BaseEntity
    {
        public UserEntity User { get; set; }
        public long UserId { get; set; }
        public string AddressName { get; set; }
        public int AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
    }
}
