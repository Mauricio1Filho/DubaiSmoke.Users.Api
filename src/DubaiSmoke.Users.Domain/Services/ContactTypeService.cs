using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using ErrorHandler.Models;
using System.Net;
using System.Threading.Tasks;
using static ErrorHandler.Models.ErrorHandlerNotification.ClientError;

namespace DubaiSmoke.Users.Domain.Services
{
    public class ContactTypeService : IContactTypeService
    {
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly ErrorHandlerNotification _notifications;

        public ContactTypeService(IContactTypeRepository contactTypeRepository, ErrorHandlerNotification notifications)
        {
            _contactTypeRepository = contactTypeRepository;
            _notifications = notifications;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _contactTypeRepository.DeleteAsync(id);

            if (!result)
                await _notifications.Handle(new ErrorDetail("Tipo do contato não encontrado", "011", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<ContactTypeEntity> SelectAsync(long id)
        {
            var result = await _contactTypeRepository.SelectAsync(id);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Tipo do contato nõ encontrado", "012", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<long> InsertAsync(ContactTypeEntity contactType)
        {
            var result = await _contactTypeRepository.InsertAsync(contactType);

            if (result < 1)
                await _notifications.Handle(new ErrorDetail("Erro ao cadastrar tipo do contato", "013", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<ContactTypeEntity> UpdateAsync(ContactTypeEntity contactType)
        {
            var result = await _contactTypeRepository.UpdateAsync(contactType);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Erro ao atualizar tipo do contato", "014", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }
    }
}
