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
            CreateMap<YugiohCardDto, YugiohCard>();
            CreateMap<Models.Type, TypeDto>();
            CreateMap<TypeDto, Models.Type>();
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<Reviewer, ReviewerDto>();
            CreateMap<ReviewerDto, Reviewer>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Deck, DeckDto>();
            CreateMap<DeckDto, Deck>();
        }
    }
}
