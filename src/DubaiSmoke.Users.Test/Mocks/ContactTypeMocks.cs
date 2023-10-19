using Bogus;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System;

namespace DubaiSmoke.Users.Test.Mocks
{
    public static class ContactTypeMocks
    {

        public static ContactTypeEntity GetContactTypeEntity()
        {
            var faker = new Faker("pt_BR");
            return new ContactTypeEntity
            {
                Id = faker.Random.Long(0, 9999),
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                HashCode = Guid.NewGuid().ToString(),
                Name = "Celular"
            };
        }

        public static ContactTypePayloadViewModel GetContactTypePayloadViewModel() => new()
        {
            name = "Celular",
        };

        public static ContactTypeViewModel GetContactTypeViewModel()
        {
            var faker = new Faker("pt_BR");
            return new ContactTypeViewModel
            {
                id = faker.Random.Long(0, 9999),
                name = "Celular",
            };
        }
    }
}
