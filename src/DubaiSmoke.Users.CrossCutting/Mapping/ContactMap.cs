using Dapper.FluentMap.Mapping;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ContactMap : EntityMap<ContactEntity>
    {
        public ContactMap()
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.UserId).ToColumn("ID_USER");
            Map(m => m.TypeId).ToColumn("ID_TYPE");
            Map(m => m.Value).ToColumn("TXT_VALUE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
