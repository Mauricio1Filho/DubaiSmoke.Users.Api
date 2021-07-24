using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Services
{
    public class ContactTypeService : IContactTypeService
    {
        private IContactTypeRepository _contacyTypeRepository;

        public ContactTypeService(IContactTypeRepository contactTypeRepository)
        {
            _contacyTypeRepository = contactTypeRepository;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _contacyTypeRepository.DeleteAsync(id);
        }

        public async Task<ContactTypeEntity> SelectAsync(long id)
        {
            return await _contacyTypeRepository.SelectAsync(id);
        }

        public async Task<long> InsertAsync(ContactTypeEntity contactType)
        {
            return await _contacyTypeRepository.InsertAsync(contactType);
        }

        public async Task<ContactTypeEntity> UpdateAsync(ContactTypeEntity contactType)
        {
            return await _contacyTypeRepository.UpdateAsync(contactType);
        }
    }
}
