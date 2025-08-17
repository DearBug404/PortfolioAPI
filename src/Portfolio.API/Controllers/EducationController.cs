using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Exceptions;
using Portfolio.Application.Interfaces;
namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddEducation([FromBody] EducationCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Education data cannot be null.");
            }
            try
            {
                var education = await _educationService.AddEducationAsync(dto);
                return Ok(education);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the education.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEducation(Guid id, [FromBody] EducationCreateDto dto)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(Problem(title: "Invalid ID", statusCode: 400));
            }
            try
            {
                var Education = await _educationService.UpdateEducationAsync(id, dto);
                return Ok(Education);
            }
            catch (NotFoundException ex)
            {
                return NotFound(Problem(title: "Education not found", detail: ex.Message, statusCode: 404));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the education.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEducation()
        {
            try
            {
                var educations = await _educationService.GetAllEducationAsync();
                if (educations == null || !educations.Any())
                {
                    return NotFound(new { Message = "No Educations found." });
                }
                return Ok(educations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving educations.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEducation(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _educationService.DeleteEducationAsync(id);
                return Ok(new { Message = "Education deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the education.", Details = ex.Message });
            }

        }

    }
}
