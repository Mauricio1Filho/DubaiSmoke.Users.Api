using DubaiSmoke.Users.Application.ViewModels;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Interfaces
{
    public interface IUserServiceApp
    {
        Task<UserViewModel> SelectAsync(long id);
        Task<long> InsertAsync(UserPayloadViewModel user);
        Task<bool> LoginAsync(LoginPayloadViewModel payload);
        Task<bool> UpdateAsync(UserPayloadViewModel user);
        Task<bool> DeleteAsync(long id);
    }
}
