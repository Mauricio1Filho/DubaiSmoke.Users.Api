namespace DubaiSmoke.Users.Domain.Aggregates
{
    public class AddressAggregate : BaseAggregate
    {
       // public UserAggregate User { get; set; }
        public long UserId { get; set; }
        public string AddressName { get; set; }
        public int AddressNumber { get; set; }
        public string AddressComplement { get; set; }
        public string PostalCode { get; set; }
    }
}
