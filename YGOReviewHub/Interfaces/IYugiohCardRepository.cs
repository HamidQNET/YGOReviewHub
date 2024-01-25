using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface IYugiohCardRepository
    {
        ICollection<YugiohCard> GetYugiohCards();
    }
}
