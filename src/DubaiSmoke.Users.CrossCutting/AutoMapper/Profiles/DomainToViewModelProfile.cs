﻿using AutoMapper;
using DubaiSmoke.Users.Application.ViewModels;
using DubaiSmoke.Users.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace DubaiSmoke.Users.CrossCutting.AutoMapper.Profiles
{
    [ExcludeFromCodeCoverage]
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<UserEntity, UserViewModel>()
                .ForMember(dest => dest.birthDay, opt => opt.MapFrom(src => src.BirthDay.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));
            CreateMap<AddressEntity, AddressViewModel>();
            CreateMap<ContactEntity, ContactViewModel>();
            CreateMap<ContactTypeEntity, ContactTypeViewModel>();
        }
    }
}
