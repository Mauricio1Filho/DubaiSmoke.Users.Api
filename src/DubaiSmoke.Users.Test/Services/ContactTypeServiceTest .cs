using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DubaiSmoke.Users.Test.Services
{
    public class ContactTypeServiceTest
    {
        ContactTypeService _contactTypeService;
        Mock<IContactTypeRepository> _contactTypeRepositoryMock;

        public ContactTypeServiceTest()
        {
            _contactTypeRepositoryMock = new Mock<IContactTypeRepository>();
            _contactTypeService = new ContactTypeService(_contactTypeRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_DeleteAsync(long id)
        {
            _contactTypeRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).Returns(Task.FromResult(true));
            var result = await _contactTypeService.DeleteAsync(id);
            Assert.True(result);
        }

        [Theory]
        [InlineData(1)]
        public async Task Must_SelectAsync(long id)
        {
            _contactTypeRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).Returns(Task.FromResult(new ContactTypeEntity()));
            var result = await _contactTypeService.SelectAsync(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Must_InsertAsync()
        {
            _contactTypeRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<ContactTypeEntity>())).Returns(Task.FromResult(1L));
            var result = await _contactTypeService.InsertAsync(new ContactTypeEntity());
            Assert.True(result > 0);
        }

        [Fact]
        public async Task Must_UpdateAsync()
        {
            _contactTypeRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<ContactTypeEntity>())).Returns(Task.FromResult(new ContactTypeEntity()));
            var result = await _contactTypeService.UpdateAsync(new ContactTypeEntity());
            Assert.NotNull(result);
        }
    }
}
