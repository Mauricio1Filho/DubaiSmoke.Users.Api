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

        private readonly IContactService _contactService;
        public ContactServiceApp(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(ContactPayloadViewModel contact)
        {
            return await _contactService.InsertAsync(_mapper.Map<ContactEntity>(contact));
        }

        public async Task<ContactViewModel> SelectAsync(long id)
        {
            return _mapper.Map<ContactViewModel>(await _contactService.SelectAsync(id));
        }

        public async Task<ContactViewModel> UpdateAsync(ContactPayloadViewModel contact)
        {
            return _mapper.Map<ContactViewModel>(await _contactService.UpdateAsync(_mapper.Map<ContactEntity>(contact)));
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _contactService.DeleteAsync(id);
        }

        public async Task<List<ContactViewModel>> SelectByUserIdAsync(long userId)
        {
            return _mapper.Map<List<ContactViewModel>>(await _contactService.SelectByUserIdAsync(userId));
        }
    }
}
