using YGOReviewHub.Models;

namespace YGOReviewHub.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetReviews();
        Review GetReview(int reviewId);
        ICollection<Review> GetReviewsOfAYugiohCard(int yugiId);
        bool ReviewExists(int reviewId);
    }
}
