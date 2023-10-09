using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using ErrorHandler.Models;
using System.Net;
using System.Threading.Tasks;
using static ErrorHandler.Models.ErrorHandlerNotification.ClientError;

namespace DubaiSmoke.Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ErrorHandlerNotification _notifications;

        public UserService(IUserRepository userRepository, ErrorHandlerNotification notification)
        {
            _userRepository = userRepository;
            _notifications = notification;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var user = await _userRepository.DeleteAsync(id);

            if (!user)
                await _notifications.Handle(new ErrorDetail($"Usuário não encontrado", "015", string.Empty, HttpStatusCode.NotFound));

            return user;
        }

        public async Task<UserEntity> SelectAsync(long id)
        {
            var result = await _userRepository.SelectAsync(id);

            if (result is null)
                await _notifications.Handle(new ErrorDetail($"Usuário não encontrado", "016", string.Empty, HttpStatusCode.NotFound));

            return result;
        }

        public async Task<long> InsertAsync(UserEntity user)
        {
            var result = await _userRepository.InsertAsync(user);

            if (result < 1)
                await _notifications.Handle(new ErrorDetail($"Erro ao cadastrar usuário", "017", string.Empty, HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            var result = await _userRepository.UpdateAsync(user);

            if (result is null)
                await _notifications.Handle(new ErrorDetail($"Erro ao atualizar usuário", "018", string.Empty, HttpStatusCode.UnprocessableEntity));

            return result;
        }

        public async Task<bool> LoginAsync(UserEntity user)
        {
            var result = await _userRepository.LoginAsync(user);

            if (!result)
                await _notifications.Handle(new ErrorDetail($"Falha no login", "019", string.Empty, HttpStatusCode.NotFound));

            return result;
        }
    }
}
