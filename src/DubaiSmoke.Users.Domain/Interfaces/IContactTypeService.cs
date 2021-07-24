using DubaiSmoke.Users.Domain.Entities;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Interfaces
{
    public interface IContactTypeService
    {
        Task<long> InsertAsync(ContactTypeEntity contacyType);
        Task<ContactTypeEntity> UpdateAsync(ContactTypeEntity contacyType);
        Task<bool> DeleteAsync(long id);
        Task<ContactTypeEntity> SelectAsync(long id);
    }
}
