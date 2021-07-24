using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DubaiSmoke.Users.Test.Services
{
    public class AddressServiceTest
    {
        AddressService _addressService;
        Mock<IAddressRepository> _addressRepositoryMock;

        public AddressServiceTest()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _addressService = new AddressService(_addressRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_DeleteAsync(long id)
        {
            _addressRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(true));
            var result = await _addressService.DeleteAsync(id);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_SelectAsync(long id)
        {
            _addressRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).Returns(Task.FromResult(new AddressEntity()));
            var result = await _addressService.SelectAsync(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Must_InsertAsync()
        {
            _addressRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<AddressEntity>())).Returns(Task.FromResult(1L));
            var result = await _addressService.InsertAsync(new AddressEntity());
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Must_UpdateAsync()
        {
            _addressRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<AddressEntity>())).Returns(Task.FromResult(new AddressEntity()));
            var result = await _addressService.UpdateAsync(new AddressEntity());
            Assert.NotNull(result);
        }
    }
}
