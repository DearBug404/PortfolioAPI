using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IntroController : ControllerBase
    {
        private readonly IIntroService _introService;
        public IntroController(IIntroService introService)
        {
            _introService = introService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddOrUpdateIntro([FromForm] IntroCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var intro = await _introService.AddOrUpdateIntroAsync(dto);
                return Ok(intro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while adding the intro section.", Details = ex.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIntro()
        {
            try
            {
                var intro = await _introService.GetIntroAsync();
                if (intro == null)
                {
                    return NotFound(new { Message = "Intro section not found." });
                }
                return Ok(intro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the intro section.", Details = ex.Message });
            }
        }
    }
}
