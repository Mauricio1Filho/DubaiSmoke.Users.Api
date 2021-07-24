using Dapper.FluentMap;
using DubaiSmoke.Users.CrossCutting.Mapping;

namespace DubaiSmoke.Users.CrossCutting.Configuration
{
    public static class DbMapping
    {
        public static void InitializeMapping()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserMap());
                config.AddMap(new AddressMap());
                config.AddMap(new ContactMap());
                config.AddMap(new ContactTypeMap());
            });
        }
    }
}
