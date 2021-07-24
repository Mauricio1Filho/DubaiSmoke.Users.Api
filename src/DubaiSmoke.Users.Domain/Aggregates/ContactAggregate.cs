namespace DubaiSmoke.Users.Domain.Aggregates
{
    public class ContactAggregate : BaseAggregate
    {
        public long UserId { get; set; }
        public long TypeId { get; set; }
        public string Value { get; set; }
        public ContactTypeAggregate ContactType { get; set; }
       // public UserAggregate User { get; set; }
    }
}
