using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillSectionController : ControllerBase
    {
       private readonly ISkillSectionService _skillSectionService;
        public SkillSectionController(ISkillSectionService skillSectionService)
        {
            _skillSectionService = skillSectionService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddSkillSection([FromBody] SkillSectionCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Skill section data is required.");
            }
            try
            {
                var skillSection = await _skillSectionService.AddOrUpdateSkillSectionAsync(dto);
                return Ok(skillSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the skill section.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSkillSection()
        {
            try
            {
                var skillSection = await _skillSectionService.GetSkillSectionAsync();
                if (skillSection == null)
                {
                    return NotFound("Skill section not found.");
                }
                return Ok(skillSection);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the skill section.", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSkillService(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _skillSectionService.DeleteSkillSectionAsync(id);
                return Ok(new { Message = "Skill deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the skill.", Details = ex.Message });
            }
        }
    }
}
