using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Moq;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
{
    public class AddressServiceTest
    {
        AddressService _addressService;
        Mock<IAddressRepository> _addressRepositoryMock;
        ErrorHandlerNotification _notifications;

        public AddressServiceTest()
        {
            _notifications = new ErrorHandlerNotification();
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _addressService = new AddressService(_addressRepositoryMock.Object, _notifications);

            _addressRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _addressRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressEntity());
            _addressRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<AddressEntity>())).ReturnsAsync(1);
            _addressRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<AddressEntity>())).ReturnsAsync(AddressMocks.GetAddressEntity());
            _addressRepositoryMock.Setup(s => s.GetAddressByUserId(It.IsAny<long>())).ReturnsAsync(AddressMocks.GetAddressEntityList());
        }

        #region Success
        [Fact]
        public async void DeleteAddressSuccess() => Assert.True(await _addressService.DeleteAsync(1));

        [Fact]
        public async void SelectAddressSuccess() => Assert.NotNull(await _addressService.SelectAsync(1));

        [Fact]
        public async void InsertAddressSuccess() => Assert.True(await _addressService.InsertAsync(AddressMocks.GetAddressEntity()) > 0);

        [Fact]
        public async void GetAddressByUserIdSuccess() => Assert.NotNull(await _addressService.GetAddressByUserId(1));

        [Fact]
        public async void UpdateAddressSuccess() => Assert.NotNull(await _addressService.UpdateAsync(AddressMocks.GetAddressEntity()));
        #endregion

        #region Error
        [Fact]
        public async void InsertAddressError()
        {
            _addressRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<AddressEntity>()));
            Assert.True(await _addressService.InsertAsync(AddressMocks.GetAddressEntity()) < 1);
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void SelectAddressError()
        {
            _addressRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>()));
            Assert.Null(await _addressService.SelectAsync(1));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void UpdateAddressError()
        {
            _addressRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<AddressEntity>()));
            Assert.Null(await _addressService.UpdateAsync(AddressMocks.GetAddressEntity()));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void DeleteAddressError()
        {
            _addressRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _addressService.DeleteAsync(0));
            Assert.True(_notifications.HasNotifications());
        }
        #endregion
    }
}
