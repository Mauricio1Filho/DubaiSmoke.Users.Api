using DubaiSmoke.Users.Domain.Entities;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<bool> LoginAsync(UserEntity user);
    }
}
