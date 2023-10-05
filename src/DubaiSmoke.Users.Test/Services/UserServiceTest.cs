using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using ErrorHandler.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DubaiSmoke.Users.Test.Services
{
    public class UserServiceTest
    {
        UserService _userService;
        Mock<IUserRepository> _userRepositoryMock;
        ErrorHandlerNotification _notification;
        public UserServiceTest()
        {
            _notification = new ErrorHandlerNotification();
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object, _notification);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_DeleteAsync(long id)
        {
            _userRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(true));
            var result = await _userService.DeleteAsync(id);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_SelectAsync(long id)
        {
            _userRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).Returns(Task.FromResult(new UserEntity()));
            var result = await _userService.SelectAsync(id);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task MustError_SelectAsync(long id)
        {
            _userRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).Throws(new Exception("Erro"));
            await Assert.ThrowsAsync<Exception>(() => _userService.SelectAsync(id));
        }

        [Fact]
        public async Task Must_InsertAsync()
        {
            _userRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<UserEntity>())).Returns(Task.FromResult(1L));
            var result = await _userService.InsertAsync(new UserEntity());
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Must_UpdateAsync()
        {
            _userRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<UserEntity>())).Returns(Task.FromResult(new UserEntity()));
            var result = await _userService.UpdateAsync(new UserEntity());  
            Assert.NotNull(result);
        }
    }
}
