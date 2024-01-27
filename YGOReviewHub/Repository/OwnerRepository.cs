using YGOReviewHub.Data;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;

namespace YGOReviewHub.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public Owner GetOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnerOfAYugiohCard(int yugiId)
        {
            return _context.YugiohCardOwners.Where(y => y.YugiohCard.Id == yugiId).Select(o => o.Owner).ToList();   
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<YugiohCard> GetYugiohCardByOwner(int ownerId)
        {
            return _context.YugiohCardOwners.Where(y => y.Owner.Id == ownerId).Select(y => y.YugiohCard).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o =>  o.Id == ownerId);
        }
    }
}
