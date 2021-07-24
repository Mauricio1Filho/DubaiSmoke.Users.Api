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

        private readonly IContactTypeService _contactTypeService;
        public ContactTypeServiceApp(IContactTypeService contactTypeService, IMapper mapper)
        {
            _contactTypeService = contactTypeService;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(ContactTypePayloadViewModel contactType)
        {
            return await _contactTypeService.InsertAsync(_mapper.Map<ContactTypeEntity>(contactType));
        }

        public async Task<ContactTypeViewModel> SelectAsync(long id)
        {
            return _mapper.Map<ContactTypeViewModel>(await _contactTypeService.SelectAsync(id));
        }

        public async Task<ContactTypeViewModel> UpdateAsync(ContactTypeViewModel contactType)
        {
            return _mapper.Map<ContactTypeViewModel>(await _contactTypeService.UpdateAsync(_mapper.Map<ContactTypeEntity>(contactType)));
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return _mapper.Map<bool>(await _contactTypeService.DeleteAsync(id));
        }
    }
}
