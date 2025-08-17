using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;
using Portfolio.Infrastructure.Service;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillDetailController : ControllerBase
    {
        private readonly ISkillDetailService _skillDetailService;

        public SkillDetailController(ISkillDetailService skillDetailService)
        {
            _skillDetailService = skillDetailService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddSkillDetail([FromBody] SkillDetailCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var skilldetail = await _skillDetailService.AddSkillDetailAsync(dto);
                return Ok(skilldetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the skill detail.", Details = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSkillDetail(Guid id, [FromBody] SkillDetailCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedSkillDetail = await _skillDetailService.UpdateSkillDetailAsync(id, dto);
                return Ok(updatedSkillDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while updating the skill detail.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSkillDetails()
        {

            var skillDetails = await _skillDetailService.GetAllSkillDetailAsync();
            if (skillDetails == null)
            {
                return NotFound(new { Message = "No skill details found." });
            }
            return Ok(skillDetails);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSkillDetail(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _skillDetailService.DeleteSkillDetailAsync(id);
                return Ok(new { Message = "Skill detail deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "Skill detail not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the skill detail.", Details = ex.Message });
            }
        }
    }
}
