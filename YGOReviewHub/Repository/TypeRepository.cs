using YGOReviewHub.Data;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;

namespace YGOReviewHub.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private DataContext _context;

        public TypeRepository(DataContext context)
        {
            _context = context;
        }

        public Models.Type GetType(int Id)
        {
            return _context.Types.Where(y => y.Id == Id).FirstOrDefault();
        }

        public ICollection<Models.Type> GetTypes()
        {
            return _context.Types.ToList();
        }

        public ICollection<YugiohCard> GetYugiohCardByType(int typeId)
        {
            return _context.YugiohCardTypes.Where(t => t.TypeId == typeId).Select(y => y.YugiohCard).ToList();
        }

        public bool TypeExists(int id)
        {
            return _context.Types.Any(y => y.Id == id);
        }
    }
}
