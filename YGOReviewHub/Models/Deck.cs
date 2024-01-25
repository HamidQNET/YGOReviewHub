namespace YGOReviewHub.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeckType { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
