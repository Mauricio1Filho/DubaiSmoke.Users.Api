using AutoMapper;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.AutoMapper.Profiles
{
    [ExcludeFromCodeCoverage]
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
            CreateMap<LoginPayloadViewModel, UserEntity>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.password));
        }
    }
}
