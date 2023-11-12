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

        private readonly IAddressService _service;

        public AddressServiceApp(IAddressService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<AddressViewModel> SelectAsync(long id) => _mapper.Map<AddressViewModel>(await _service.SelectAsync(id));

        public async Task<long> InsertAsync(AddressPayloadViewModel address) => await _service.InsertAsync(_mapper.Map<AddressEntity>(address));

        public async Task<bool> UpdateAsync(AddressPayloadViewModel address) => await _service.UpdateAsync(_mapper.Map<AddressEntity>(address));

        public async Task<bool> DeleteAsync(long id) => await _service.DeleteAsync(id);

        public async Task<List<AddressViewModel>> GetAddressByUserId(long userId) => _mapper.Map<List<AddressViewModel>>(await _service.GetAddressByUserId(userId));
    }
}
