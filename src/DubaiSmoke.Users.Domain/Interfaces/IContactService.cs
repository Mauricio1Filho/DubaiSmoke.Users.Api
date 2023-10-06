using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Interfaces
{
    public interface IContactService
    {
        Task<long> InsertAsync(ContactEntity contact);
        Task<ContactEntity> UpdateAsync(ContactEntity contact);
        Task<bool> DeleteAsync(long id);
        Task<ContactEntity> SelectAsync(long id);
        Task<List<ContactEntity>> SelectByUserIdAsync(long userId);
    }
}
