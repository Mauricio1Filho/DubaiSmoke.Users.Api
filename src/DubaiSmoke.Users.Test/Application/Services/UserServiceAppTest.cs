using AutoMapper;
using DubaiSmoke.Users.Application.Services;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Test.Mocks;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Application.Services
{
    public class UserServiceAppTest
    {
        readonly UserServiceApp _mockServiceApp;
        readonly Mock<IUserService> _userService;
        readonly Mock<IMapper> _mapper;
        public UserServiceAppTest()
        {
            _userService = new Mock<IUserService>();
            _mapper = new Mock<IMapper>();
            _mockServiceApp = new UserServiceApp(_userService.Object, _mapper.Object);

            _userService.Setup(x => x.InsertAsync(It.IsAny<UserEntity>())).ReturnsAsync(1);
            _userService.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(UserMocks.GetUserEntity());
            _userService.Setup(x => x.UpdateAsync(It.IsAny<UserEntity>())).ReturnsAsync(true);
            _userService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _userService.Setup(x => x.LoginAsync(It.IsAny<UserEntity>())).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<UserViewModel>(It.IsAny<UserEntity>())).Returns(UserMocks.GetUserViewModel());
        }

        #region Success
        [Fact]
        public async void InsertUserSuccess() => Assert.True(await _mockServiceApp.InsertAsync(UserMocks.GetUserPayloadViewModel()) > 0);

        [Fact]
        public async void SelectUserSuccess() => Assert.NotNull(await _mockServiceApp.SelectAsync(1));

        [Fact]
        public async void UpdateUserSuccess() => Assert.True(await _mockServiceApp.UpdateAsync(UserMocks.GetUserPayloadViewModel()));

        [Fact]
        public async void DeleteUserSuccess() => Assert.True(await _mockServiceApp.DeleteAsync(1));

        [Fact]
        public async void LoginSuccess() => Assert.True(await _mockServiceApp.LoginAsync(UserMocks.GetLoginPayloadViewModel()));
        #endregion

        #region Error
        [Fact]
        public async void InsertUserError()
        {
            _userService.Setup(x => x.InsertAsync(It.IsAny<UserEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.InsertAsync(UserMocks.GetUserPayloadViewModel()));
        }

        [Fact]
        public async void SelectUserError()
        {
            _userService.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.SelectAsync(0));
        }

        [Fact]
        public async void UpdateUserError()
        {
            _userService.Setup(x => x.UpdateAsync(It.IsAny<UserEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.UpdateAsync(UserMocks.GetUserPayloadViewModel()));
        }

        [Fact]
        public async void DeleteUserError()
        {
            _userService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _mockServiceApp.DeleteAsync(0));
        }

        [Fact]
        public async void LoginError()
        {
            _userService.Setup(x => x.LoginAsync(It.IsAny<UserEntity>())).ReturnsAsync(false);
            Assert.False(await _mockServiceApp.LoginAsync(UserMocks.GetLoginPayloadViewModel()));
        }
        #endregion
    }
}
