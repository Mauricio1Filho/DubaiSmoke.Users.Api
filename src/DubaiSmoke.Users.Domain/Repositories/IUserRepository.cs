using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> GetUserByEmail(string email);
        Task<List<UserEntity>> GetByName(string name);
    }
}
