using Dapper.FluentMap.Mapping;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.Mapping
{
    [ExcludeFromCodeCoverage]
    public class ContactTypeMap : EntityMap<ContactTypeEntity>
    {
        public ContactTypeMap()
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Name).ToColumn("TXT_NAME");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.DeletedAt).ToColumn("DT_DELETED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
