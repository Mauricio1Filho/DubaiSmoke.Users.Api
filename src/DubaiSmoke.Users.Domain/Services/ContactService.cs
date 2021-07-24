using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _contactRepository.DeleteAsync(id);
        }

        public async Task<ContactEntity> SelectAsync(long id)
        {
            return await _contactRepository.SelectAsync(id);
        }

        public async Task<long> InsertAsync(ContactEntity contact)
        {
            return await _contactRepository.InsertAsync(contact);
        }

        public async Task<ContactEntity> UpdateAsync(ContactEntity contact)
        {
            return await _contactRepository.UpdateAsync(contact);
        }

        public async Task<List<ContactEntity>> SelectByUserIdAsync(long userId)
        {
            return await _contactRepository.SelectByUserIdAsync(userId);
        }
    }
}
