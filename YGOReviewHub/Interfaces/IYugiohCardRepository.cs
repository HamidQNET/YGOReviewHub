using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface IYugiohCardRepository
    {
        ICollection<YugiohCard> GetYugiohCards();
        YugiohCard GetYugiohCard(int id);
        YugiohCard GetYugiohCard(string name);
        decimal GetYugiohCardRating(int yugiId);
        bool YugiohCardExists(int yugiId);
    }
}
