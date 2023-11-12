using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using ErrorHandler.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static ErrorHandler.Models.ErrorHandlerNotification.ClientError;

namespace DubaiSmoke.Users.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly ErrorHandlerNotification _notifications;

        public ContactService(IContactRepository contactRepository, ErrorHandlerNotification notifications)
        {
            _contactRepository = contactRepository;
            _notifications = notifications;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _contactRepository.DeleteAsync(id);

            if (!result)
                await _notifications.Handle(new ErrorDetail("Contato não encontrado", "006", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<ContactEntity> SelectAsync(long id)
        {
            var result = await _contactRepository.SelectAsync(id);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Contato não encontrado", "007", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<long> InsertAsync(ContactEntity contact)
        {
            contact.HashCode = Guid.NewGuid().ToString();

            var result = await _contactRepository.InsertAsync(contact);

            if (result < 1)
                await _notifications.Handle(new ErrorDetail("Erro ao cadastrar contato", "008", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<bool> UpdateAsync(ContactEntity contact)
        {
            contact.UpdatedAt = DateTime.Now;

            var result = await _contactRepository.UpdateAsync(contact);

            if (!result)
                await _notifications.Handle(new ErrorDetail("Erro ao atualizar contato", "009", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<List<ContactEntity>> SelectByUserIdAsync(long userId)
        {
            var result = await _contactRepository.SelectByUserIdAsync(userId);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Contato não encontrado", "010", "", HttpStatusCode.NotFound));

            return result;
        }
    }
}
