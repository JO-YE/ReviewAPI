
using Microsoft.AspNetCore.Mvc;
using ReviewAPI.Interfaces;
using ReviewAPI.Model;
using ReviewAPI.Services;

namespace ReviewAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;

        public ReviewController(IReviewServices reviewServices)
        {
            _reviewServices = reviewServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {
            var reviews = await _reviewServices.GetAllReviewsAsync();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            var review = await _reviewServices.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(Review review)
        {
            var newReview = await _reviewServices.AddReviewAsync(review);
            return CreatedAtAction(nameof(GetReview), new { id = newReview.Id }, newReview);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _reviewServices.DeleteReviewAsync(id);
            return NoContent();
        }
    }
}
