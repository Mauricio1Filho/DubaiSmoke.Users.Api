using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _addressRepository.DeleteAsync(id);
        }

        public async Task<AddressEntity> SelectAsync(long id)
        {
            return await _addressRepository.SelectAsync(id);
        }
        

        public async Task<long> InsertAsync(AddressEntity address)
        {
            return await _addressRepository.InsertAsync(address);
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity address)
        {
            return await _addressRepository.UpdateAsync(address);
        }

        public async Task<List<AddressEntity>> GetAddressByUserId(long userId)
        {
            return await _addressRepository.GetAddressByUserId(userId);
        }
    }
}
