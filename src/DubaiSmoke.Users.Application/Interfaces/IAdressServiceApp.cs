using DubaiSmoke.Users.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Interfaces
{
    public interface IAddressServiceApp
    {
        Task<AddressViewModel> SelectAsync(long id);
        Task<long> InsertAsync(AddressPayloadViewModel address);
        Task<AddressViewModel> UpdateAsync(AddressPayloadViewModel address);
        Task<bool> DeleteAsync(long id);
        Task<List<AddressViewModel>> GetAddressByUserId(long userId);
    }
}
