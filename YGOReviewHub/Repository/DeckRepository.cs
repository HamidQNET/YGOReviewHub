using System.Text;
using YGOReviewHub.Data;
using YGOReviewHub.Interfaces;
using YGOReviewHub.Models;

namespace YGOReviewHub.Repository
{
    public class DeckRepository : IDeckRepository
    {
        private readonly DataContext _context;

        public DeckRepository(DataContext context)
        {
            _context = context;
        }

        public bool DeckExists(int Id)
        {
            return _context.Decks.Any(d => d.Id == Id);
        }

        public Deck GetDeck(int deckId)
        {
            return _context.Decks.Where(d => d.Id == deckId).FirstOrDefault();
        }

        public Deck GetDeckByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(c => c.Deck).FirstOrDefault();
        }

        public ICollection<Deck> GetDecks()
        {
            return _context.Decks.ToList();
        }

        public ICollection<Owner> GetOwnerOfADeck(int deckId)
        {
            return _context.Owners.Where(d => d.Deck.Id == deckId).ToList();
        }
    }
}
