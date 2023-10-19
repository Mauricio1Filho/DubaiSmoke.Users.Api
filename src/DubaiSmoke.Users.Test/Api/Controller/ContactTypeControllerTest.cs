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
    public class ContactTypeControllerTest
    {
        readonly ContactTypeController _controller;
        readonly Mock<IContactTypeServiceApp> _contactTypeServiceApp;
        readonly ErrorHandlerNotification _notifications;
        public ContactTypeControllerTest()
        {
            _notifications = new ErrorHandlerNotification();
            _contactTypeServiceApp = new Mock<IContactTypeServiceApp>();
            _controller = new ContactTypeController(_contactTypeServiceApp.Object, _notifications);

            _contactTypeServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactTypePayloadViewModel>())).ReturnsAsync(1);
            _contactTypeServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactTypeMocks.GetContactTypeViewModel());
            _contactTypeServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeViewModel>())).ReturnsAsync(true);
            _contactTypeServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
        }

        #region Success
        [Fact]
        public async void InsertContactTypeSuccess() => Assert.IsType<OkObjectResult>(await _controller.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));

        [Fact]
        public async void SelectContactTypeSuccess() => Assert.IsType<OkObjectResult>(await _controller.SelectAsync(1));

        [Fact]
        public async void UpdateContactTypeSuccess() => Assert.IsType<OkObjectResult>(await _controller.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));

        [Fact]
        public async void DeleteContactTypeSuccess() => Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(1));
        #endregion

        #region Error
        [Fact]
        public async void InsertContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactTypePayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));
        }

        [Fact]
        public async void SelectContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));
        }

        [Fact]
        public async void DeleteContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(0));
        }
        #endregion
    }
}
