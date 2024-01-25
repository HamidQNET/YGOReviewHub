namespace YGOReviewHub.Models
{
    public class YugiohCardOwner
    {
        public int YugiohCardId { get; set; }
        public int OwnerId { get; set; }
        public YugiohCard YugiohCard { get; set; }
        public Owner Owner { get; set; }

    }
}
