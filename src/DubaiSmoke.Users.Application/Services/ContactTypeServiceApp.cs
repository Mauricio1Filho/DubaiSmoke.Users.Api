using AutoMapper;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Services
{
    public class ContactTypeServiceApp : IContactTypeServiceApp
    {
        private readonly IMapper _mapper;

        private readonly IContactTypeService _service;

        public ContactTypeServiceApp(IContactTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<ContactTypeViewModel> SelectAsync(long id) => _mapper.Map<ContactTypeViewModel>(await _service.SelectAsync(id));

        public async Task<long> InsertAsync(ContactTypePayloadViewModel contactType) => await _service.InsertAsync(_mapper.Map<ContactTypeEntity>(contactType));

        public async Task<bool> UpdateAsync(ContactTypeViewModel contactType) => await _service.UpdateAsync(_mapper.Map<ContactTypeEntity>(contactType));

        public async Task<bool> DeleteAsync(long id) => await _service.DeleteAsync(id);
    }
}
