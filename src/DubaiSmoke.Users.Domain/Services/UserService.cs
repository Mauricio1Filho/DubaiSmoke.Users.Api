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
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<UserEntity> SelectAsync(long id)
        {
            var user = await _userRepository.SelectAsync(id);

            if (user is null)
                await _notifications.Handle(new ErrorDetail($"Usuário não encontrado: {id}", "001", string.Empty, HttpStatusCode.NotFound));

            return user;
        }

        public async Task<long> InsertAsync(UserEntity user)
        {
            return await _userRepository.InsertAsync(user);
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            return await _userRepository.UpdateAsync(user);
        }

        public async Task<bool> LoginAsync(UserEntity user)
        {
            return await _userRepository.LoginAsync(user);
        }
    }
}
