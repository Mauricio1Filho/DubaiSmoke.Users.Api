using DubaiSmoke.Users.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Interfaces
{
    public interface IUserServiceApp
    {
        Task<UserViewModel> SelectAsync(long id);
        Task<List<UserViewModel>> GetUserByName(string name);
        Task<UserViewModel> GetUserByEmail(string email);
        Task<long> InsertAsync(UserPayloadViewModel user);
        Task<UserViewModel> UpdateAsync(UserViewModel user);
        Task<bool> DeleteAsync(long id);
    }
}
