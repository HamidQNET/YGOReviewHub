using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface IDeckRepository
    {
        ICollection<Deck> GetDecks();
        Deck GetDeck(int deckId);
        Deck GetDeckByOwner(int ownerId);
        ICollection<Owner> GetOwnerOfADeck(int deckId);
        bool DeckExists(int deckId);
        bool CreateDeck(Deck deck);
        bool Save();

    }
}
