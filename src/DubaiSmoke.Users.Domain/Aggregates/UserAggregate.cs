using System;

namespace DubaiSmoke.Users.Domain.Aggregates
{
    public class UserAggregate
    {     
        public long userId { get; set; }
        public string name { get; set; }
        public DateTime birthday { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }
}
