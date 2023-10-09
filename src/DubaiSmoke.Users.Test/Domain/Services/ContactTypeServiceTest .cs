using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
{
    public class ContactTypeServiceTest
    {
        ContactTypeService _contactTypeService;
        Mock<IContactTypeRepository> _contactTypeRepositoryMock;
        ErrorHandlerNotification _notifications;
        public ContactTypeServiceTest()
        {
            _notifications = new ErrorHandlerNotification();
            _contactTypeRepositoryMock = new Mock<IContactTypeRepository>();
            _contactTypeService = new ContactTypeService(_contactTypeRepositoryMock.Object, _notifications);

            _contactTypeRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _contactTypeRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactTypeMocks.GetContactTypeEntity());
            _contactTypeRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(1);
            _contactTypeRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(ContactTypeMocks.GetContactTypeEntity());
        }

        #region Success
        [Fact]
        public async Task DeleteContactTypeSuccess() => Assert.True(await _contactTypeService.DeleteAsync(1));

        [Fact]
        public async Task SelectContactTypeSuccess() => Assert.NotNull(await _contactTypeService.SelectAsync(1));

        [Fact]
        public async Task InsertContactTypeSuccess() => Assert.True(await _contactTypeService.InsertAsync(ContactTypeMocks.GetContactTypeEntity()) > 0);

        [Fact]
        public async Task UpdateContactTypeSuccess() => Assert.NotNull(await _contactTypeService.UpdateAsync(ContactTypeMocks.GetContactTypeEntity()));
        #endregion

        #region Error
        [Fact]
        public async void InsertContactTypeError()
        {
            _contactTypeRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<ContactTypeEntity>()));
            Assert.True(await _contactTypeService.InsertAsync(ContactTypeMocks.GetContactTypeEntity()) < 1);
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void SelectContactTypeError()
        {
            _contactTypeRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>()));
            Assert.Null(await _contactTypeService.SelectAsync(0));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void UpdateContactTypeError()
        {
            _contactTypeRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeEntity>()));
            Assert.Null(await _contactTypeService.UpdateAsync(ContactTypeMocks.GetContactTypeEntity()));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void DeleteContactTypeError()
        {
            _contactTypeRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _contactTypeService.DeleteAsync(0));
            Assert.True(_notifications.HasNotifications());
        }
        #endregion
    }
}
