using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);
        ICollection<Owner> GetOwnerOfAYugiohCard(int yugiId);
        ICollection<YugiohCard> GetYugiohCardByOwner(int ownerId);
        bool OwnerExists(int ownerId);

    }
}
