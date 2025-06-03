using ReviewAPI.Model;

namespace ReviewAPI.Interfaces
{
    public interface IReviewServices
    {
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task<Review?> GetReviewByIdAsync(int id);
        Task<Review> AddReviewAsync(Review review);
        Task DeleteReviewAsync(int id);
    }
}
