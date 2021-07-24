using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<UserEntity> SelectAsync(long id)
        {
            return await _userRepository.SelectAsync(id);
        }

        public async Task<long> InsertAsync(UserEntity user)
        {
            return await _userRepository.InsertAsync(user);
        }

        public async Task<UserEntity> UpdateAsync(UserEntity user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    }
}
