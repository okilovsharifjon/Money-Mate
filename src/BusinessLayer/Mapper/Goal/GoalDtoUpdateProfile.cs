using AutoMapper;
using DataAccess;


namespace BusinessLayer
{
    public class GoalDtoUpdateProfile : Profile
    {
        public GoalDtoUpdateProfile()
        {
            CreateMap<GoalDtoUpdate, Goal>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountOfMoney, opt => opt.MapFrom(src => src.AmountOfMoney))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term))
                .ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountOfMoney, opt => opt.MapFrom(src => src.AmountOfMoney))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term));
        }
    }
}
