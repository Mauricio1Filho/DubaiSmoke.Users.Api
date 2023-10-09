using Bogus;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DubaiSmoke.Users.Test.Mocks
{
    public static class ContactMocks
    {

        public static ContactEntity GetContactEntity()
        {
            var faker = new Faker("pt_BR");
            return new ContactEntity
            {
                Id = faker.Random.Long(0, 9999),
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                DeletedAt = null,
                HashCode = Guid.NewGuid().ToString(),
                ContactType = ContactTypeMocks.GetContactTypeEntity()
            };
        }

        public static ContactPayloadViewModel GetContactPayloadViewModel()
        {
            var faker = new Faker("pt_BR");
            return new ContactPayloadViewModel
            {
                typeId = faker.Random.Long(0, 9999),
                userId = faker.Random.Long(0, 9999),
                value = "valeu"
            };
        }

        public static ContactViewModel GetContactViewModel()
        {
            var faker = new Faker("pt_BR");
            return new ContactViewModel
            {
                typeId = faker.Random.Long(0, 9999),
                userId = faker.Random.Long(0, 9999),
                value = "valeu",
                user = UserMocks.GetUserViewModel(),
                contactType = ContactTypeMocks.GetContactTypeViewModel()
            };
        }

        public static List<ContactEntity> GetContactEntityList() => new List<ContactEntity>
            {
               GetContactEntity(),
               GetContactEntity(),
               GetContactEntity(),
               GetContactEntity()
            };

        public static List<ContactViewModel> GetContactViewModelList() => new List<ContactViewModel>
            {
               GetContactViewModel(),
               GetContactViewModel(),
               GetContactViewModel(),
               GetContactViewModel()
            };
    }
}
