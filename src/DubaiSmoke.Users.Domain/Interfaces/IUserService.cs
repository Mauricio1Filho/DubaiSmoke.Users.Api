using DubaiSmoke.Users.Domain.Entities;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Interfaces
{
    public interface IUserService
    {
        Task<long> InsertAsync(UserEntity user);
        Task<bool> UpdateAsync(UserEntity user);
        Task<bool> DeleteAsync(long id);
        Task<UserEntity> SelectAsync(long id);
        Task<bool> LoginAsync(UserEntity user);
    }
}
