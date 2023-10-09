using Bogus;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DubaiSmoke.Users.Test.Mocks
{
    public static class AddressMocks
    {

        public static AddressEntity GetAddressEntity()
        {
            var faker = new Faker("pt_BR");
            return new AddressEntity
            {
                Id = faker.Random.Long(0, 9999),
                CreatedAt = DateTime.Now,
                UpdatedAt = null,
                DeletedAt = null,
                HashCode = Guid.NewGuid().ToString(),
                AddressComplement = string.Empty,
                AddressName = faker.Address.StreetAddress(),
                AddressNumber = int.Parse(faker.Address.BuildingNumber()),
                PostalCode = faker.Address.ZipCode(),
                User = UserMocks.GetUserEntity(),
                UserId = UserMocks.GetUserEntity().Id
            };
        }

        public static AddressPayloadViewModel GetAddressPayloadViewModel()
        {
            var faker = new Faker("pt_BR");
            return new AddressPayloadViewModel
            {
                addressComplement = string.Empty,
                addressName = faker.Address.StreetAddress(),
                addressNumber = int.Parse(faker.Address.BuildingNumber()),
                postalCode = faker.Address.ZipCode(),
                userId = UserMocks.GetUserEntity().Id
            };
        }

        public static AddressViewModel GetAddressViewModel()
        {
            var faker = new Faker("pt_BR");
            return new AddressViewModel
            {
                userId = UserMocks.GetUserEntity().Id,
                addressComplement = string.Empty,
                addressName = faker.Address.StreetAddress(),
                addressNumber = int.Parse(faker.Address.BuildingNumber()),
                postalCode = faker.Address.ZipCode(),
                user = UserMocks.GetUserViewModel()
            };
        }

        public static List<AddressEntity> GetAddressEntityList() => new List<AddressEntity>
            {
               GetAddressEntity(),
               GetAddressEntity(),
               GetAddressEntity(),
               GetAddressEntity()
            };

        public static List<AddressViewModel> GetAddressViewModelList() => new List<AddressViewModel>
            {
               GetAddressViewModel(),
               GetAddressViewModel(),
               GetAddressViewModel(),
               GetAddressViewModel()
            };
    }
}
