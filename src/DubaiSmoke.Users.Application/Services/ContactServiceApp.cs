using AutoMapper;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Services
{
    public class ContactServiceApp : IContactServiceApp
    {
        private readonly IMapper _mapper;

        private readonly IContactService _service;

        public ContactServiceApp(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ContactViewModel> SelectAsync(long id) => _mapper.Map<ContactViewModel>(await _service.SelectAsync(id));

        public async Task<List<ContactViewModel>> SelectByUserIdAsync(long userId) => _mapper.Map<List<ContactViewModel>>(await _service.SelectByUserIdAsync(userId));

        public async Task<long> InsertAsync(ContactPayloadViewModel contact) => await _service.InsertAsync(_mapper.Map<ContactEntity>(contact));

        public async Task<ContactViewModel> UpdateAsync(ContactPayloadViewModel contact) => _mapper.Map<ContactViewModel>(await _service.UpdateAsync(_mapper.Map<ContactEntity>(contact)));

        public async Task<bool> DeleteAsync(long id) => await _service.DeleteAsync(id);
    }
}
