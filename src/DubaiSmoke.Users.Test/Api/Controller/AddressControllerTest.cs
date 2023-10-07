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
    public class AddressControllerTest
    {
        readonly AddressController _controller;
        readonly Mock<IAddressServiceApp> _addressServiceApp;
        readonly ErrorHandlerNotification _notifications;
        public AddressControllerTest()
        {
            _notifications = new ErrorHandlerNotification();
            _addressServiceApp = new Mock<IAddressServiceApp>();
            _controller = new AddressController(_addressServiceApp.Object, _notifications);

            _addressServiceApp.Setup(x => x.InsertAsync(It.IsAny<AddressPayloadViewModel>())).ReturnsAsync(1);
            _addressServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressViewModel());
            _addressServiceApp.Setup(x => x.UpdateAsync(It.IsAny<AddressPayloadViewModel>())).ReturnsAsync(AddressMocks.GetAddressViewModel());
            _addressServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _addressServiceApp.Setup(x => x.GetAddressByUserId(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressViewModelList());
        }

        #region Success
        [Fact]
        public async void InsertAddressSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.InsertAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void GetAddressByUserIdSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.GetAddressByUserId(1));
        }

        [Fact]
        public async void SelectAddressSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.SelectAsync(1));
        }

        [Fact]
        public async void UpdateAddressSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.UpdateAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void DeleteAddressSuccess()
        {
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(1));
        }
        #endregion

        #region Error
        [Fact]
        public async void InsertAddressError()
        {
            _addressServiceApp.Setup(x => x.InsertAsync(It.IsAny<AddressPayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.InsertAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void GetAddressByUserIdError()
        {
            _addressServiceApp.Setup(x => x.GetAddressByUserId(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.GetAddressByUserId(1));
        }

        [Fact]
        public async void SelectAddressError()
        {
            _addressServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.SelectAsync(0));
        }

        [Fact]
        public async void UpdateAddressError()
        {
            _addressServiceApp.Setup(x => x.UpdateAsync(It.IsAny<AddressPayloadViewModel>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.UpdateAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void DeleteAddressError()
        {
            _addressServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.IsType<OkObjectResult>(await _controller.DeleteAsync(0));
        }
        #endregion
    }
}
