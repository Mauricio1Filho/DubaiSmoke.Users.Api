using Bogus;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System;

namespace DubaiSmoke.Users.Test.Mocks
{
    public static class UserMocks
    {

        public static UserEntity GetUserEntity()
        {
            var faker = new Faker("pt_BR");
            return new UserEntity
            {
                BirthDay = DateTime.Now,
                CreatedAt = DateTime.Now,
                DeletedAt = null,
                HashCode = Guid.NewGuid().ToString(),
                Id = faker.Random.Long(0, 9999),
                Login = faker.Internet.Email(),
                Name = faker.Person.FullName,
                Password = faker.Internet.Password(15),
                UpdatedAt = null
            };
        }

        public static UserPayloadViewModel GetUserPayloadViewModel()
        {
            var faker = new Faker("pt_BR");
            return new UserPayloadViewModel
            {
                birthDay = DateTime.Now.ToString(),
                login = faker.Internet.Email(),
                name = faker.Person.FullName,
                password = faker.Internet.Password(15)
            };
        }

        public static UserViewModel GetUserViewModel()
        {
            var faker = new Faker("pt_BR");
            return new UserViewModel
            {
                id = faker.Random.Long(0, 999),
                birthDay = DateTime.Now.ToString(),
                login = faker.Internet.Email(),
                name = faker.Person.FullName,
                password = faker.Internet.Password(15)
            };
        }

        public static LoginPayloadViewModel GetLoginPayloadViewModel()
        {
            var faker = new Faker("pt_BR");
            return new LoginPayloadViewModel
            {
                email = faker.Internet.Email(),
                password = faker.Internet.Password(15)
            };
        }
    }
}
