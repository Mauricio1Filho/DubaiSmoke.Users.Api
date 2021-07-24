using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Repositories
{
    public interface IAddressRepository : IRepository<AddressEntity>
    {
        Task <List<AddressEntity>> GetAddressByUserId(long userId);
    }
}
