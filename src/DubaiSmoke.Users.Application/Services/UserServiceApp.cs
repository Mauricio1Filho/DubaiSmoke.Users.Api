using AutoMapper;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using System.Threading.Tasks;

namespace DubaiSmoke.Users.Application.Services
{
    public class UserServiceApp : IUserServiceApp
    {
        private readonly IMapper _mapper;

        private readonly IUserService _userService;
        public UserServiceApp(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(UserPayloadViewModel user)
        {
            return await _userService.InsertAsync(_mapper.Map<UserEntity>(user));
        }

        public async Task<UserViewModel> SelectAsync(long id)
        {
            return _mapper.Map<UserViewModel>(await _userService.SelectAsync(id));
        }

        public async Task<UserViewModel> UpdateAsync(UserViewModel user)
        {
            return _mapper.Map<UserViewModel>(await _userService.UpdateAsync(_mapper.Map<UserEntity>(user)));
        }

        public async Task<bool> DeleteAsync(long id)
        {
            return _mapper.Map<bool>(await _userService.DeleteAsync(id));
        }
    }
}
