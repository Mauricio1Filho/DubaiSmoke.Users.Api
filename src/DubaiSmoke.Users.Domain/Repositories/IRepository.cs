using DubaiSmoke.Users.Domain.Entities;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<long> InsertAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(long id);
        Task<T> SelectAsync(long id);
    }
}
