

using AutoMapper;
using DataAccess;

namespace BusinessLayer
{
    public class AccountDtoUpdateProfile : Profile
    {
        public AccountDtoUpdateProfile()
        {
            CreateMap<Account, AccountDtoUpdate>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance))
                .ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
        }
    }
}
