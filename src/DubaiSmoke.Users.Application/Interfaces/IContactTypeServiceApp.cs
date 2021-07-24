using DubaiSmoke.Users.Application.ViewModels;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Interfaces
{
    public interface IContactTypeServiceApp
    {
        Task<ContactTypeViewModel> SelectAsync(long id);
        Task<long> InsertAsync(ContactTypePayloadViewModel contactType);
        Task<ContactTypeViewModel> UpdateAsync(ContactTypeViewModel contactType);
        Task<bool> DeleteAsync(long id);
    }
}
