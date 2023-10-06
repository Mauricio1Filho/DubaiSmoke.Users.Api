using AutoMapper;
using DubaiSmoke.Users.Api.Controllers;
using DubaiSmoke.Users.Application.Interfaces;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using DubaiSmoke.Users.Test.Mocks;
using Moq;
using System;
using Xunit;

namespace DubaiSmoke.Users.Test.Api.Controller
{
    public class ContactTypeControllerTest
    {
        readonly ContactTypeController _controller;
        readonly Mock<IContactTypeServiceApp> _contactTypeServiceApp;
        readonly Mock<IMapper> _mapper;
        public ContactTypeControllerTest()
        {
            _contactTypeServiceApp = new Mock<IContactTypeServiceApp>();
            _mapper = new Mock<IMapper>();
            _controller = new ContactTypeController(_contactTypeServiceApp.Object);

            _contactTypeServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(1);
            _contactTypeServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ReturnsAsync(ContactTypeMocks.GetContactTypeEntity());
            _contactTypeServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeEntity>())).ReturnsAsync(ContactTypeMocks.GetContactTypeEntity());
            _contactTypeServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(true);
            _mapper.Setup(x => x.Map<ContactTypeViewModel>(It.IsAny<ContactTypeEntity>())).Returns(ContactTypeMocks.GetContactTypeViewModel());
        }

        #region Success
        [Fact]
        public async void InsertContactTypeSuccess()
        {
            Assert.Equal(1, await _controller.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));
        }

        [Fact]
        public async void SelectContactTypeSuccess()
        {
            Assert.NotNull(await _controller.SelectAsync(1));
        }

        [Fact]
        public async void UpdateContactTypeSuccess()
        {
            Assert.NotNull(await _controller.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));
        }

        [Fact]
        public async void DeleteContactTypeSuccess()
        {
            Assert.True(await _controller.DeleteAsync(1));
        }
        #endregion

        #region Error
        [Fact]
        public async void InsertContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.InsertAsync(It.IsAny<ContactTypeEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.InsertAsync(ContactTypeMocks.GetContactTypePayloadViewModel()));
        }

        [Fact]
        public async void SelectContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.SelectAsync(It.IsAny<long>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.SelectAsync(0));
        }

        [Fact]
        public async void UpdateContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.UpdateAsync(It.IsAny<ContactTypeEntity>())).ThrowsAsync(new Exception());
            await Assert.ThrowsAnyAsync<Exception>(async () => await _controller.UpdateAsync(ContactTypeMocks.GetContactTypeViewModel()));
        }

        [Fact]
        public async void DeleteContactTypeError()
        {
            _contactTypeServiceApp.Setup(x => x.DeleteAsync(It.IsAny<long>())).ReturnsAsync(false);
            Assert.False(await _controller.DeleteAsync(0));
        }
        #endregion
    }
}
