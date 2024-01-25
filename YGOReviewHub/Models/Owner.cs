namespace YGOReviewHub.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Deck Deck { get; set; }
        public ICollection<YugiohCardOwner> YugiohCardOwners { get; set; }
    }
}
