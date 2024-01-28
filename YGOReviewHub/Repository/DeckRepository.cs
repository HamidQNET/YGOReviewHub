﻿using System.Text;
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

        public bool CreateDeck(Deck deck)
        {
            _context.Add(deck);
            return Save();
        }

        public bool DeckExists(int deckId)
        {
            return _context.Decks.Any(d => d.Id == deckId);
        }

        public bool DeleteDeck(Deck deck)
        {
            _context.Remove(deck);
            return Save();  
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

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDeck(Deck deck)
        {
            _context.Update(deck);
            return Save();
        }
    }
}
