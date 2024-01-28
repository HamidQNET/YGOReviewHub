using YGOReviewHub.Data;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;

namespace YGOReviewHub.Repository
{
    public class YugiohCardRepository : IYugiohCardRepository
    {
        private readonly DataContext _context;

        public YugiohCardRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateYugiohCard(int ownerId, int typeId, YugiohCard yugiohcard)
        {
            var yugiohcardOwnerEntity = _context.Owners.Where(a => a.Id == ownerId).FirstOrDefault(); 
            var type = _context.Types.Where(a => a.Id == typeId).FirstOrDefault();

            var yugiohcardOwner = new YugiohCardOwner()
            {
                Owner = yugiohcardOwnerEntity,
                YugiohCard = yugiohcard
            };

            _context.Add(yugiohcardOwner);

            var yugiohcardType = new YugiohCardType()
            {
                Type = type,
                YugiohCard = yugiohcard
            };

            _context.Add(yugiohcardType);

            _context.Add(yugiohcard);

            return Save();
        }

        public YugiohCard GetYugiohCard(int id)
        {
            return _context.YugiohCards.Where(y => y.Id == id).FirstOrDefault();
        }

        public YugiohCard GetYugiohCard(string name)
        {
            return _context.YugiohCards.Where(y => y.Name == name).FirstOrDefault();
        }

        public decimal GetYugiohCardRating(int yugiId)
        {
            var review = _context.Reviews.Where(y => y.YugiohCard.Id == yugiId);

            if (review.Count() <= 0)
                return 0;

            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public ICollection<YugiohCard> GetYugiohCards()
        {
            return _context.YugiohCards.OrderBy(y => y.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool YugiohCardExists(int yugiId)
        {
            return _context.YugiohCards.Any(y =>  y.Id == yugiId);
        }
    }
}
