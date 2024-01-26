using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface ITypeRepository
    {
        ICollection<Models.Type> GetTypes();
        Models.Type GetType(int Id);
        ICollection<YugiohCard> GetYugiohCardByType(int typeId);
        bool TypeExists(int id);
    }
}
