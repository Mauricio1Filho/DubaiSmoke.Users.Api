using AutoMapper;
using DubaiSmoke.Users.Api.Controllers;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.Services;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DubaiSmoke.Users.Test.Api.Controller
{
    public class ContactControllerTest
    {
        readonly ContactController _controller;
        readonly Mock<IContactServiceApp> _contactServiceApp;
        readonly ErrorHandlerNotification _notifications;
        public ContactControllerTest()
        {
            _notifications = new ErrorHandlerNotification();
            _contactServiceApp = new Mock<IContactServiceApp>();
            _controller = new ContactController(_contactServiceApp.Object, _notifications);

            _contactServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactPayloadViewModel>())).ReturnsAsync(1);
            _contactServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactViewModel());
            _contactServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactPayloadViewModel>())).ReturnsAsync(ContactMocks.GetContactViewModel());
            _contactServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _contactServiceApp.Setup(x => x.SelectByUserIdAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactViewModelList());
        }

        #region Success
        [Fact]
        public async void InsertContactSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.InsertAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void SelectContactSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.SelectAsync(1));
        }

        [Fact]
        public async void UpdateContactSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.UpdateAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void DeleteContactSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(1));
        }

        [Fact]
        public async void SelectByUserIdSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.SelectByUserIdAsync(1));
        }

        #endregion

        #region Error
        [Fact]
        public async void InsertContactError()
        {
            _contactServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactPayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.InsertAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void SelectContactError()
        {
            _contactServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactError()
        {
            _contactServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactPayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.UpdateAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void DeleteContactError()
        {
            _contactServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(0));
        }

        [Fact]
        public async void SelectByUserIdError()
        {
            _contactServiceApp.Setup(x => x.SelectByUserIdAsync(It.IsAny<long>()));
            Assert.IsType<OkObjectResult>(await _controller.SelectByUserIdAsync(1));
        }
        #endregion
    }
}
