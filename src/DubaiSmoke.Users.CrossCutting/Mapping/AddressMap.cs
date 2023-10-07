using Dapper.FluentMap.Mapping;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.Mapping
{
    public class AddressMap : EntityMap<AddressEntity>
    {
        [ExcludeFromCodeCoverage]
        public AddressMap()
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.UserId).ToColumn("ID_USER");
            Map(m => m.AddressName).ToColumn("TXT_ADDRESS");
            Map(m => m.AddressNumber).ToColumn("NR_ADDRESS");
            Map(m => m.AddressComplement).ToColumn("TXT_COMPLEMENT");
            Map(m => m.PostalCode).ToColumn("TXT_POSTAL_CODE");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.DeletedAt).ToColumn("DT_DELETED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
