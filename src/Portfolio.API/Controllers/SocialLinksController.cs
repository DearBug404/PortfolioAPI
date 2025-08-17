using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Interfaces;
using Portfolio.Application.DTOs;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocialLinksController : ControllerBase
    {
        private readonly ISocialLinksService _socialLinksService;
        public SocialLinksController(ISocialLinksService socialLinksService)
        {
            _socialLinksService = socialLinksService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddSocialLink([FromForm] SocialLinksCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _socialLinksService.AddOrUpdateSocialLinksAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the social links.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSocialLinks()
        {
            try
            {
                var result = await _socialLinksService.GetAllSocialLinksAsync();
                if (result == null)
                {
                    return NotFound(new { Message = "No social links found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the social links.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSocialLink(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _socialLinksService.DeleteSocialLinksAsync(id);
                return Ok(new { Message = "Social links deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Social link not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the social link.", Details = ex.Message });
            }
        }
    }
}
