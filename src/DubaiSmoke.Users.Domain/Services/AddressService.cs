using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using ErrorHandler.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static ErrorHandler.Models.ErrorHandlerNotification.ClientError;

namespace DubaiSmoke.Users.Domain.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;
        private ErrorHandlerNotification _notifications;

        public AddressService(IAddressRepository addressRepository, ErrorHandlerNotification notifications)
        {
            _addressRepository = addressRepository;
            _notifications = notifications;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _addressRepository.DeleteAsync(id);

            if (!result)
                await _notifications.Handle(new ErrorDetail("Endereço não encontrado", "001", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<AddressEntity> SelectAsync(long id)
        {
            var result = await _addressRepository.SelectAsync(id);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Endereço não encontrado", "002", "", HttpStatusCode.NotFound));

            return result;
        }

        public async Task<long> InsertAsync(AddressEntity address)
        {
            var result = await _addressRepository.InsertAsync(address);

            if (result < 1)
                await _notifications.Handle(new ErrorDetail($"Erro ao cadastrar endereço", "003", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<AddressEntity> UpdateAsync(AddressEntity address)
        {
            var result = await _addressRepository.UpdateAsync(address);

            if (result is null)
                await _notifications.Handle(new ErrorDetail($"Erro ao atualizar endereço", "004", "", HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<List<AddressEntity>> GetAddressByUserId(long userId)
        {
            var result = await _addressRepository.GetAddressByUserId(userId);

            if (result is null)
                await _notifications.Handle(new ErrorDetail("Endereço não encontrado", "005", "", HttpStatusCode.NotFound));

            return result;
        }
    }
}
