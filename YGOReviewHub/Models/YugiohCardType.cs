namespace YGOReviewHub.Models
{
    public class YugiohCardType
    {
        public int YugiohCardId { get; set; }
        public int TypeId { get; set; }
        public YugiohCard YugiohCard { get; set; }
        public Type Type { get; set; }
    }
}
