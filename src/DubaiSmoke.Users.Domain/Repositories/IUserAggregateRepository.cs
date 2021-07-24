using DubaiSmoke.Users.Domain.Aggregates;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IUserAggregateRepository
    {
        Task<string> InsertAsync(UserAggregate user);
    }
}
