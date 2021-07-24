using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Interfaces
{
    public interface IUserService
    {
        Task<long> InsertAsync(UserEntity user);
        Task<UserEntity> UpdateAsync(UserEntity user);
        Task<bool> DeleteAsync(long id);
        Task<UserEntity> SelectAsync(long id);
        Task<List<UserEntity>> GetUserByName(string name);
        Task<UserEntity> GetUserByEmail(string email);
    }
}
