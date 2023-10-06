using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
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

            _userRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _userRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(UserMocks.GetUserEntity());
            _userRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<UserEntity>())).ReturnsAsync(1);
            _userRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<UserEntity>())).ReturnsAsync(UserMocks.GetUserEntity());
            _userRepositoryMock.Setup(s => s.LoginAsync(It.IsAny<UserEntity>())).ReturnsAsync(true);
        }

        #region Success
        [Fact]
        public async void DeleteUserSuccess()
        {
            Assert.True(await _userService.DeleteAsync(1));
        }

        [Fact]
        public async void SelectUserSuccess()
        {
            Assert.NotNull(await _userService.SelectAsync(1));
        }

        [Fact]
        public async void InsertUserSuccess()
        {
            Assert.True(await _userService.InsertAsync(UserMocks.GetUserEntity()) > 0);
        }

        [Fact]
        public async void UpdateUserSuccess()
        {
            Assert.NotNull(await _userService.UpdateAsync(UserMocks.GetUserEntity()));
        }

        [Fact]
        public async void LoginSuccess()
        {
            Assert.True(await _userService.LoginAsync(UserMocks.GetUserEntity()));
        }
        #endregion

        #region Error
        [Fact]
        public async void InsertUserError()
        {
            _userRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<UserEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _userService.InsertAsync(UserMocks.GetUserEntity()));
        }

        [Fact]
        public async void SelectUserError()
        {
            _userRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _userService.SelectAsync(0));
        }

        [Fact]
        public async void UpdateUserError()
        {
            _userRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<UserEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _userService.UpdateAsync(UserMocks.GetUserEntity()));
        }

        [Fact]
        public async void DeleteUserError()
        {
            _userRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _userService.DeleteAsync(0));
        }

        [Fact]
        public async void LoginError()
        {
            _userRepositoryMock.Setup(x => x.LoginAsync(It.IsAny<UserEntity>())).ReturnsAsync(false);
            Assert.False(await _userService.LoginAsync(UserMocks.GetUserEntity()));
        }
        #endregion
    }
}
