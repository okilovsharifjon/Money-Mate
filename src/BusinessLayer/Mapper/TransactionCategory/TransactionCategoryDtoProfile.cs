using AutoMapper;
using DataAccess;

namespace BusinessLayer
{
    public class TransactionCategoryDtoProfile : Profile
    {
        public TransactionCategoryDtoProfile()
        {
            CreateMap<TransactionCategoryDto, TransactionCategory>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
