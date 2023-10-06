using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
{
    public class AddressServiceTest
    {
        AddressService _addressService;
        Mock<IAddressRepository> _addressRepositoryMock;

        public AddressServiceTest()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _addressService = new AddressService(_addressRepositoryMock.Object);

            _addressRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _addressRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressEntity());
            _addressRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<AddressEntity>())).ReturnsAsync(1);
            _addressRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(AddressMocks.GetAddressEntity());
        }

        #region Success
        [Fact]
        public async void DeleteAddressSuccess()
        {
            Assert.True(await _addressService.DeleteAsync(1));
        }

        [Fact]
        public async void SelectAddressSuccess()
        {
            Assert.NotNull(await _addressService.SelectAsync(1));
        }

        [Fact]
        public async void InsertAddressSuccess()
        {
            Assert.True(await _addressService.InsertAsync(AddressMocks.GetAddressEntity()) > 0);
        }

        [Fact]
        public async void UpdateAddressSuccess()
        {
            Assert.NotNull(await _addressService.UpdateAsync(AddressMocks.GetAddressEntity()));
        }
        #endregion

        #region Error
        [Fact]
        public async void InsertAddressError()
        {
            _addressRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<AddressEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _addressService.InsertAsync(AddressMocks.GetAddressEntity()));
        }

        [Fact]
        public async void SelectAddressError()
        {
            _addressRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _addressService.SelectAsync(0));
        }

        [Fact]
        public async void UpdateAddressError()
        {
            _addressRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<AddressEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _addressService.UpdateAsync(AddressMocks.GetAddressEntity()));
        }

        [Fact]
        public async void DeleteAddressError()
        {
            _addressRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _addressService.DeleteAsync(0));
        }
        #endregion
    }
}
