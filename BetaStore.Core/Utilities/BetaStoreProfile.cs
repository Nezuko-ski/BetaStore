using AutoMapper;
using BetaStore.Core.DTOs;
using BetaStore.Domain.Entities;

namespace BetaStore.Core.Utilities
{
    public class BetaStoreProfile : Profile
    {
        public BetaStoreProfile()
        {
            CreateMap<Customer, UserDTO>().ReverseMap().ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.ToLower()));
        }
    }
}
