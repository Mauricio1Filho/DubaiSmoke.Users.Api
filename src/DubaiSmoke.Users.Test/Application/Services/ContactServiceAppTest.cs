using AutoMapper;
using DubaiSmoke.Users.Application.Services;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Domain.Interfaces;
using DubaiSmoke.Users.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DubaiSmoke.Users.Test.Application.Services
{
    public class ContactServiceAppTest
    {
        readonly ContactServiceApp _mockServiceApp;
        readonly Mock<IContactService> _contactService;
        readonly Mock<IMapper> _mapper;
        public ContactServiceAppTest()
        {
            _contactService = new Mock<IContactService>();
            _mapper = new Mock<IMapper>();
            _mockServiceApp = new ContactServiceApp(_contactService.Object, _mapper.Object);

            _contactService.Setup(x => x.InsertAsync(It.IsAny<ContactEntity>())).ReturnsAsync(1);
            _contactService.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactEntity());
            _contactService.Setup(x => x.UpdateAsync(It.IsAny<ContactEntity>())).ReturnsAsync(ContactMocks.GetContactEntity());
            _contactService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _contactService.Setup(x => x.SelectByUserIdAsync(It.IsAny<long>())).ReturnsAsync(ContactMocks.GetContactEntityList());
            _mapper.Setup(x => x.Map<ContactViewModel>(It.IsAny<ContactEntity>())).Returns(ContactMocks.GetContactViewModel());
            _mapper.Setup(x => x.Map<List<ContactViewModel>>(It.IsAny<List<ContactEntity>>())).Returns(ContactMocks.GetContactViewModelList());
        }

        #region Success
        [Fact]
        public async void InsertContactSuccess() => Assert.True(await _mockServiceApp.InsertAsync(ContactMocks.GetContactPayloadViewModel()) > 0);

        [Fact]
        public async void SelectContactSuccess() => Assert.NotNull(await _mockServiceApp.SelectAsync(1));

        [Fact]
        public async void UpdateContactSuccess() => Assert.NotNull(await _mockServiceApp.UpdateAsync(ContactMocks.GetContactPayloadViewModel()));

        [Fact]
        public async void DeleteContactSuccess() => Assert.True(await _mockServiceApp.DeleteAsync(1));

        [Fact]
        public async void SelectByUserIdSuccess() => Assert.NotNull(await _mockServiceApp.SelectByUserIdAsync(1));

        #endregion

        #region Error
        [Fact]
        public async void InsertContactError()
        {
            _contactService.Setup(x => x.InsertAsync(It.IsAny<ContactEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.InsertAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void SelectContactError()
        {
            _contactService.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactError()
        {
            _contactService.Setup(x => x.UpdateAsync(It.IsAny<ContactEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.UpdateAsync(ContactMocks.GetContactPayloadViewModel()));
        }

        [Fact]
        public async void DeleteContactError()
        {
            _contactService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _mockServiceApp.DeleteAsync(0));
        }

        [Fact]
        public async void SelectByUserIdError()
        {
            _mapper.Setup(x => x.Map<List<ContactViewModel>>(It.IsAny<List<ContactEntity>>()));
            _contactService.Setup(x => x.SelectByUserIdAsync(It.IsAny<long>()));
            Assert.Null(await _mockServiceApp.SelectByUserIdAsync(1));
        }

        #endregion
    }
}
