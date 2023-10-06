using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Repositories;
using DubaiSmoke.Users.Domain.Services;
using DubaiSmoke.Users.Test.Mocks;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Domain.Services
{
    public class ContactServiceTest
    {
        ContactService _contactService;
        Mock<IContactRepository> _contactRepositoryMock;

        public ContactServiceTest()
        {
            _contactRepositoryMock = new Mock<IContactRepository>();
            _contactService = new ContactService(_contactRepositoryMock.Object);

            _contactRepositoryMock.Setup(s => s.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _contactRepositoryMock.Setup(s => s.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactEntity());
            _contactRepositoryMock.Setup(s => s.InsertAsync(It.IsAny<ContactEntity>())).ReturnsAsync(1);
            _contactRepositoryMock.Setup(s => s.UpdateAsync(It.IsAny<ContactEntity>())).ReturnsAsync(ContactMocks.GetContactEntity());
        }

        #region Success
        [Fact]
        public async void DeleteContactSuccess()
        {
            Assert.True(await _contactService.DeleteAsync(1));
        }

        [Fact]
        public async void SelectContactSuccess()
        {
            Assert.NotNull(await _contactService.SelectAsync(1));
        }

        [Fact]
        public async void InsertContactSuccess()
        {
            Assert.True( await _contactService.InsertAsync(ContactMocks.GetContactEntity()) > 0);
        }

        [Fact]
        public async void UpdateContactSuccess()
        {
            Assert.NotNull(await _contactService.UpdateAsync(ContactMocks.GetContactEntity()));
        }
        #endregion

        #region Error
        [Fact]
        public async void InsertContactError()
        {
            _contactRepositoryMock.Setup(x => x.InsertAsync(It.IsAny<ContactEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _contactService.InsertAsync(ContactMocks.GetContactEntity()));
        }

        [Fact]
        public async void SelectContactError()
        {
            _contactRepositoryMock.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _contactService.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactError()
        {
            _contactRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<ContactEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _contactService.UpdateAsync(ContactMocks.GetContactEntity()));
        }

        [Fact]
        public async void DeleteContactError()
        {
            _contactRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _contactService.DeleteAsync(0));
        }
        #endregion
    }
}
