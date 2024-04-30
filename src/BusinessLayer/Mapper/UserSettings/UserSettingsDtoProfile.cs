
using AutoMapper;
using DataAccess;

namespace BusinessLayer
{
    public class UserSettingsDtoProfile : Profile
    {
        public UserSettingsDtoProfile()
        {
            CreateMap<UserSettingsDto, UserSettings>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ReverseMap()
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
