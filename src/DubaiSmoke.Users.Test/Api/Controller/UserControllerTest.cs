using DubaiSmoke.Users.Api.Controllers;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Api.Controller
{
    public class UserControllerTest
    {
        readonly UserController _controller;
        readonly Mock<IUserServiceApp> _userServiceApp;
        readonly ErrorHandlerNotification _notifications;
        public UserControllerTest()
        {
            _notifications = new ErrorHandlerNotification();
            _userServiceApp = new Mock<IUserServiceApp>();
            _controller = new UserController(_userServiceApp.Object, _notifications);

            _userServiceApp.Setup(x => x.InsertAsync(It.IsAny<UserPayloadViewModel>())).ReturnsAsync(1);
            _userServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(UserMocks.GetUserViewModel());
            _userServiceApp.Setup(x => x.UpdateAsync(It.IsAny<UserViewModel>())).ReturnsAsync(UserMocks.GetUserViewModel());
            _userServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _userServiceApp.Setup(x => x.LoginAsync(It.IsAny<LoginPayloadViewModel>())).ReturnsAsync(true);
        }

        #region Success
        [Fact]
        public async void InsertUserSuccess() => Assert.IsType<OkObjectResult>(await _controller.InsertAsync(UserMocks.GetUserPayloadViewModel()));

        [Fact]
        public async void SelectUserSuccess() => Assert.IsType<OkObjectResult>(await _controller.SelectAsync(1));

        [Fact]
        public async void UpdateUserSuccess() => Assert.IsType<OkObjectResult>(await _controller.UpdateAsync(UserMocks.GetUserViewModel()));

        [Fact]
        public async void DeleteUserSuccess() => Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(1));

        [Fact]
        public async void LoginSuccess() => Assert.IsType<OkObjectResult>(await _controller.Login(UserMocks.GetLoginPayloadViewModel()));
        #endregion

        #region Error
        [Fact]
        public async void InsertUserError()
        {
            _userServiceApp.Setup(x => x.InsertAsync(It.IsAny<UserPayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.InsertAsync(UserMocks.GetUserPayloadViewModel()));
        }

        [Fact]
        public async void SelectUserError()
        {
            _userServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.SelectAsync(0));
        }

        [Fact]
        public async void UpdateUserError()
        {
            _userServiceApp.Setup(x => x.UpdateAsync(It.IsAny<UserViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.UpdateAsync(UserMocks.GetUserViewModel()));
        }

        [Fact]
        public async void DeleteUserError()
        {
            _userServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(0));
        }

        [Fact]
        public async void LoginError()
        {
            _userServiceApp.Setup(x => x.LoginAsync(It.IsAny<LoginPayloadViewModel>())).ReturnsAsync(false);
            Assert.IsType<OkObjectResult>(await _controller.Login(UserMocks.GetLoginPayloadViewModel()));
        }
        #endregion
    }
}
