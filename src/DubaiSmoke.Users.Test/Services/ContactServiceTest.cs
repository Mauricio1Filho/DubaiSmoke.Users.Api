using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DubaiSmoke.Users.Test.Services
{
    public class ContactServiceTest
    {

        ContactService _contactService;
        Mock<IContactRepository> _contactRepositoryMock;

        public ContactServiceTest()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _contactService = new ContactService(_contactRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_DeleteAsync(long id)
        {
            _contactRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(true));
            var result = await _contactService.DeleteAsync(id);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_SelectAsync(long id)
        {
            _contactRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).Returns(Task.FromResult(new ContactEntity()));
            var result = await _contactService.SelectAsync(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Must_InsertAsync()
        {
            _contactRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<ContactEntity>())).Returns(Task.FromResult(1L));
            var result = await _contactService.InsertAsync(new ContactEntity());
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Must_UpdateAsync()
        {
            _contactRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<ContactEntity>())).Returns(Task.FromResult(new ContactEntity()));
            var result = await _contactService.UpdateAsync(new ContactEntity());
            Assert.NotNull(result);
        }
    }
}
