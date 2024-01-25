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

        public ICollection<YugiohCard> GetYugiohCards()
        {
            return _context.YugiohCards.OrderBy(y => y.Id).ToList();
        }
    }
}
