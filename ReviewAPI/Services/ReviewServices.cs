using Microsoft.EntityFrameworkCore;

using ReviewAPI.Data;
using ReviewAPI.Interfaces;
using ReviewAPI.Model;

namespace ReviewAPI.Services
{
    public class ReviewServices: IReviewServices
    {
        private readonly ApplicationDBContext _context;

        public ReviewServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews.ToListAsync();
        }

        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.FindAsync(id);
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task DeleteReviewAsync(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                throw new KeyNotFoundException($"Review not found");
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }



    }
}
