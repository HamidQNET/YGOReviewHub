using AutoMapper;
using YGOReviewHub.Dto;
using YGOReviewHub.Models;

namespace YGOReviewHub.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<YugiohCard, YugiohCardDto>();
            CreateMap<Models.Type, TypeDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
