using AutoMapper;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Services
{
    public class AddressServiceApp : IAddressServiceApp
    {
        private readonly IMapper _mapper;

        private readonly IAddressService _addressService;
        public AddressServiceApp(IAddressService addressService, IMapper mapper)
        {
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(AddressPayloadViewModel address)
        {
            return await _addressService.InsertAsync(_mapper.Map<AddressEntity>(address));
        }

        public async Task<AddressViewModel> SelectAsync(long id)
        {
            return _mapper.Map<AddressViewModel>(await _addressService.SelectAsync(id));
        }

        public async Task<AddressViewModel> UpdateAsync(AddressPayloadViewModel address)
        {
            return _mapper.Map<AddressViewModel>(await _addressService.UpdateAsync(_mapper.Map<AddressEntity>(address)));
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _addressService.DeleteAsync(id);
        }

        public async Task<List<AddressViewModel>> GetAddressByUserId(long userId)
        {
            return _mapper.Map<List<AddressViewModel>>(await _addressService.GetAddressByUserId(userId));
        }
    }
}
