namespace DubaiSmoke.Users.Domain.Aggregates
{
    public class ContactTypeAggregate : BaseAggregate
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
