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

        public bool CreateType(Models.Type type)
        {
            _context.Add(type);

            return Save();
        }

        public bool DeleteType(Models.Type type)
        {
            _context.Remove(type);
            return Save();
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;    
        }

        public bool TypeExists(int id)
        {
            return _context.Types.Any(y => y.Id == id);
        }

        public bool UpdateType(Models.Type type)
        {
            _context.Update(type);
            return Save();
        }
    }
}
