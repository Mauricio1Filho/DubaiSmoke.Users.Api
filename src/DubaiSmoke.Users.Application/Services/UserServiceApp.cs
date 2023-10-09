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

        private readonly IUserService _service;

        public UserServiceApp(IUserService userService, IMapper mapper)
        {
            _service = userService;
            _mapper = mapper;
        }

        public async Task<long> InsertAsync(UserPayloadViewModel user) => await _service.InsertAsync(_mapper.Map<UserEntity>(user));

        public async Task<UserViewModel> SelectAsync(long id) => _mapper.Map<UserViewModel>(await _service.SelectAsync(id));

        public async Task<UserViewModel> UpdateAsync(UserViewModel user) => _mapper.Map<UserViewModel>(await _service.UpdateAsync(_mapper.Map<UserEntity>(user)));

        public async Task<bool> DeleteAsync(long id) => await _service.DeleteAsync(id);

        public async Task<bool> LoginAsync(LoginPayloadViewModel payload) => await _service.LoginAsync(_mapper.Map<UserEntity>(payload));
    }
}
