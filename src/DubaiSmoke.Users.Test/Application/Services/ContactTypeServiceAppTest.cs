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
    public class ContactTypeServiceAppTest
    {
        readonly ContactTypeServiceApp _mockServiceApp;
        readonly Mock<IContactTypeService> _contactTypeService;
        readonly Mock<IMapper> _mapper;
        public ContactTypeServiceAppTest()
        {
            _contactTypeService = new Mock<IContactTypeService>();
            _mapper = new Mock<IMapper>();
            _mockServiceApp = new ContactTypeServiceApp(_contactTypeService.Object, _mapper.Object);

            _contactTypeService.Setup(x => x.InsertAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(1);
            _contactTypeService.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactTypeMocks.GetContactTypeEntity());
            _contactTypeService.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(true);
            _contactTypeService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<ContactTypeViewModel>(It.IsAny<ContactTypeEntity>())).Returns(ContactTypeMocks.GetContactTypeViewModel());
        }

        #region Success
        [Fact]
        public async void InsertContactTypeSuccess() => Assert.Equal(1, await _mockServiceApp.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));

        [Fact]
        public async void SelectContactTypeSuccess() => Assert.NotNull(await _mockServiceApp.SelectAsync(1));

        [Fact]
        public async void UpdateContactTypeSuccess() => Assert.NotNull(await _mockServiceApp.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));

        [Fact]
        public async void DeleteContactTypeSuccess() => Assert.True(await _mockServiceApp.DeleteAsync(1));
        #endregion

        #region Error
        [Fact]
        public async void InsertContactTypeError()
        {
            _contactTypeService.Setup(x => x.InsertAsync(It.IsAny<ContactTypeEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));
        }

        [Fact]
        public async void SelectContactTypeError()
        {
            _contactTypeService.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactTypeError()
        {
            _contactTypeService.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _mockServiceApp.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));
        }

        [Fact]
        public async void DeleteContactTypeError()
        {
            _contactTypeService.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _mockServiceApp.DeleteAsync(0));
        }
        #endregion
    }
}
