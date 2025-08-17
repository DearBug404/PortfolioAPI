using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddServices([FromForm] ServicesCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            {
                try
                {
                    var services = await _servicesService.AddServicesAsync(dto);
                    return Ok(services);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "An error occurred while adding the service.", Details = ex.Message });
                }
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateService(Guid id, [FromForm] ServicesCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            {
                try
                {
                    var services = await _servicesService.UpdateServiceAsync(id, dto);
                    return Ok(services);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { Message = "An error occurred while updating the service.", Details = ex.Message });
                }
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _servicesService.GetAllServicesAsync();
            return Ok(services);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(new { Message = "Invalid ID provided." });
            }

            try
            {
                await _servicesService.DeleteServiceAsync(id);
                return Ok(new { Message = "Service deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while deleting the service.", Details = ex.Message });
            }
        }

    }
}
