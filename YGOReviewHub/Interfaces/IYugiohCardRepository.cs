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
        bool CreateYugiohCard(int ownerId, int typeId, YugiohCard yugiohcard);
        bool UpdateYugiohCard(int ownerId, int typeId, YugiohCard yugiohcard);
        bool DeleteYugiohCard(YugiohCard yugiohCard);
        bool Save();
    }
}
