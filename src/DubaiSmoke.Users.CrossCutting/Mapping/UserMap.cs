using Dapper.FluentMap.Mapping;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.Mapping
{
    [ExcludeFromCodeCoverage]
    public class UserMap : EntityMap<UserEntity>
    {
        public UserMap()
        {
            Map(m => m.Id).ToColumn("ID");
            Map(m => m.Name).ToColumn("NM_USER");
            Map(m => m.BirthDay).ToColumn("DT_BIRTH");
            Map(m => m.Login).ToColumn("TXT_LOGIN");
            Map(m => m.Password).ToColumn("TXT_PWD");
            Map(m => m.CreatedAt).ToColumn("DT_CREATED");
            Map(m => m.UpdatedAt).ToColumn("DT_UPDATED");
            Map(m => m.HashCode).ToColumn("HASH_CODE");
        }
    }
}
