namespace YGOReviewHub.Models
{
    public class YugiohCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<YugiohCardOwner> YugiohCardOwners { get; set; }
        public ICollection<YugiohCardType> YugiohCardTypes { get; set; }
    }
}
