namespace YGOReviewHub.Models
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<YugiohCardType> YugiohCardTypes { get; set; }
    }
}
