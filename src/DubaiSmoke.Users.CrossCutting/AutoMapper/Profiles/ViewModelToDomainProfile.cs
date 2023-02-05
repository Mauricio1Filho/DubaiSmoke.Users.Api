using AutoMapper;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;

namespace DubaiSmoke.Users.CrossCutting.AutoMapper.Profiles
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UserViewModel, UserEntity>();
            CreateMap<UserPayloadViewModel, UserEntity>();
            CreateMap<AddressViewModel, AddressEntity>();
            CreateMap<AddressPayloadViewModel, AddressEntity>();
            CreateMap<ContactViewModel, ContactEntity>();
            CreateMap<ContactPayloadViewModel, ContactEntity>();
            CreateMap<ContactTypePayloadViewModel, ContactTypeEntity>();
            CreateMap<ContactTypeViewModel, ContactTypeEntity>();            
        }
    }
}
