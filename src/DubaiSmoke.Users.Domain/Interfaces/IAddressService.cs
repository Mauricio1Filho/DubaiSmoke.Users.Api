using DubaiSmoke.Users.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Interfaces
{
    public interface IAddressService
    {
        Task<long> InsertAsync(AddressEntity address);
        Task<AddressEntity> UpdateAsync(AddressEntity address);
        Task<bool> DeleteAsync(long id);
        Task<AddressEntity> SelectAsync(long id);
        Task<List<AddressEntity>> GetAddressByUserId(long userId);

    }
}
