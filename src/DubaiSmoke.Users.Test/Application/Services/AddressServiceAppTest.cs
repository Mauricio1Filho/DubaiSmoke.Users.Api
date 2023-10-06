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
    public class AddressServiceAppTest
    {
        readonly AddressServiceApp _mockServiceApp;
        readonly Mock<IAddressService> _addressService;
        readonly Mock<IMapper> _mapper;
        public AddressServiceAppTest()
        {
            _addressService = new Mock<IAddressService>();
            _mapper = new Mock<IMapper>();
            _mockServiceApp = new AddressServiceApp(_addressService.Object, _mapper.Object);

            _addressService.Setup(x => x.InsertAsync(It.IsAny<AddressEntity>())).ReturnsAsync(1);
            _addressService.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressEntity());
            _addressService.Setup(x => x.UpdateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(AddressMocks.GetAddressEntity());
            _addressService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<AddressViewModel>(It.IsAny<AddressEntity>())).Returns(AddressMocks.GetAddressViewModel());
        }

        #region Success
        [Fact]
        public async void InsertAddressSuccess()
        {
            Assert.True(await _mockServiceApp.InsertAsync(AddressMocks.GetAddressPayloadViewModel()) > 0);
        }

        [Fact]
        public async void SelectAddressSuccess()
        {
            Assert.NotNull(await _mockServiceApp.SelectAsync(1));
        }

        [Fact]
        public async void UpdateAddressSuccess()
        {
            Assert.NotNull(await _mockServiceApp.UpdateAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void DeleteAddressSuccess()
        {
            Assert.True(await _mockServiceApp.DeleteAsync(1));
        }

        #endregion

        #region Error
        [Fact]
        public async void InsertAddressError()
        {
            _addressService.Setup(x => x.InsertAsync(It.IsAny<AddressEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.InsertAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void SelectAddressError()
        {
            _addressService.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.SelectAsync(0));
        }

        [Fact]
        public async void UpdateAddressError()
        {
            _addressService.Setup(x => x.UpdateAsync(It.IsAny<AddressEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.UpdateAsync(AddressMocks.GetAddressPayloadViewModel()));
        }

        [Fact]
        public async void DeleteAddressError()
        {
            _addressService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _mockServiceApp.DeleteAsync(0));
        }
        #endregion
    }
}
