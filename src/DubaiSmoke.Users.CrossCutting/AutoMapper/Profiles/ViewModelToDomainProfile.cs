using AutoMapper;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Aggregates;
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
            CreateMap <UserAggregate, UserEntity> ()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.userId));
        }
    }
}
