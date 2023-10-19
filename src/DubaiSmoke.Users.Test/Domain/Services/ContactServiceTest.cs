using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using ErrorHandler.Models;
using Moq;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
{
    public class ContactServiceTest
    {
        readonly ContactService _contactService;
        readonly Mock<IContactRepository> _contactRepositoryMock;
        readonly ErrorHandlerNotification _notifications;

        public ContactServiceTest()
        {
            _notifications = new ErrorHandlerNotification();
            _contactRepositoryMock = new Mock<IContactRepository>();
            _contactService = new ContactService(_contactRepositoryMock.Object, _notifications);

            _contactRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _contactRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactEntity());
            _contactRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<ContactEntity>())).ReturnsAsync(1);
            _contactRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<ContactEntity>())).ReturnsAsync(true);
            _contactRepositoryMock.Setup(s => s.SelectByUserIdAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactEntityList());
        }

        #region Success
        [Fact]
        public async void DeleteContactSuccess() => Assert.True(await _contactService.DeleteAsync(1));

        [Fact]
        public async void SelectContactSuccess() => Assert.NotNull(await _contactService.SelectAsync(1));

        [Fact]
        public async void InsertContactSuccess() => Assert.True(await _contactService.InsertAsync(ContactMocks.GetContactEntity()) > 0);

        [Fact]
        public async void UpdateContactSuccess() => Assert.NotNull(await _contactService.UpdateAsync(ContactMocks.GetContactEntity()));

        [Fact]
        public async void SelectByUserIdSuccess() => Assert.NotNull(await _contactService.SelectByUserIdAsync(1));
        #endregion

        #region Error
        [Fact]
        public async void InsertContactError()
        {
            _contactRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<ContactEntity>()));
            Assert.True(await _contactService.InsertAsync(ContactMocks.GetContactEntity()) < 1);
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void SelectContactError()
        {
            _contactRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>()));
            Assert.Null(await _contactService.SelectAsync(1));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void UpdateContactError()
        {
            _contactRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<ContactEntity>()));
            Assert.False(await _contactService.UpdateAsync(ContactMocks.GetContactEntity()));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void DeleteContactError()
        {
            _contactRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _contactService.DeleteAsync(0));
            Assert.True(_notifications.HasNotifications());
        }

        [Fact]
        public async void SelectByUserIdContactError()
        {
            _contactRepositoryMock.Setup(x => x.SelectByUserIdAsync(It.IsAny<long>()));
            Assert.Null(await _contactService.SelectByUserIdAsync(1));
            Assert.True(_notifications.HasNotifications());
        }
        #endregion
    }
}
