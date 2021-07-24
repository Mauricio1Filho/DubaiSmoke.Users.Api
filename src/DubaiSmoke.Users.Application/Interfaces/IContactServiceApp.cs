using DubaiSmoke.Users.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Interfaces
{
    public interface IContactServiceApp
    {
        Task<ContactViewModel> SelectAsync(long id);
        Task<List<ContactViewModel>> SelectByUserIdAsync(long userId);

        Task<long> InsertAsync(ContactPayloadViewModel contact);
        Task<ContactViewModel> UpdateAsync(ContactPayloadViewModel contact);
        Task<bool> DeleteAsync(long id);
    }
}
