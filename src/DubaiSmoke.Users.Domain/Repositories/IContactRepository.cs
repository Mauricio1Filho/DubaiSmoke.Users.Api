using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IContactRepository : IRepository<ContactEntity>
    {
        Task<List<ContactEntity>> SelectByUserIdAsync(long userId);
    }
}
