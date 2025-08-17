using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewReview;

        public ReviewController(IReviewService reviewReview)
        {
            _reviewReview = reviewReview;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddReview([FromForm] ReviewCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            {
                try
                {
                    var review = await _reviewReview.AddReviewAsync(dto);
                    return Ok(review);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "An error occurred while adding the Review.", Details = ex.Message });
                }
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateReview(Guid id, [FromForm] ReviewCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            {
                try
                {
                    var review = await _reviewReview.UpdateReviewAsync(id, dto);
                    return Ok(review);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "An error occurred while updating the Review.", Details = ex.Message });
                }
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllReview()
        {
            var review = await _reviewReview.GetAllReviewsAsync();
            return Ok(review);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetReviewById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }
            try
            {
                var review = await _reviewReview.GetReviewByIdAsync(id);
                return Ok(review);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Review not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the Review.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _reviewReview.DeleteReviewAsync(id);
                return Ok(new { Message = "Review deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the Review.", Details = ex.Message });
            }
        }

    }
}
