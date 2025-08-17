using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Exceptions;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddExperience([FromBody] ExperienceCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Experience data cannot be null.");
            }
            try
            {
                var experience = await _experienceService.AddExperienceAsync(dto);
                return Ok(experience);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the experience.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateExperience(Guid id, [FromBody] ExperienceCreateDto dto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(Problem(title: "Invalid ID", statusCode: 400));
            }
            try
            {
                var experience = await _experienceService.UpdateExperienceAsync(id, dto);
                return Ok(experience);
            }
            catch (NotFoundException ex)
            {
                return NotFound(Problem(title: "Experience not found", detail: ex.Message, statusCode: 404));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the experience.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllExperience()
        {
            try
            {
                var experiences = await _experienceService.GetAllExperienceAsync();
                if (experiences == null || !experiences.Any())
                {
                    return NotFound(new { Message = "No experiences found." });
                }
                return Ok(experiences);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving experiences.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteExperience(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _experienceService.DeleteExperienceAsync(id);
                return Ok(new { Message = "Experience deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the experience.", Details = ex.Message });
            }

        }
    }
}
