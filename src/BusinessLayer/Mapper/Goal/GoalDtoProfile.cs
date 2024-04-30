using AutoMapper;
using DataAccess;


namespace BusinessLayer
{
    public class GoalDtoProfile : Profile
    {
        public GoalDtoProfile()
        {
            CreateMap<GoalDto, Goal>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountOfMoney, opt => opt.MapFrom(src => src.AmountOfMoney))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term))
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.AmountOfMoney, opt => opt.MapFrom(src => src.AmountOfMoney))
                .ForMember(dest => dest.Term, opt => opt.MapFrom(src => src.Term));
        }
    }
}
