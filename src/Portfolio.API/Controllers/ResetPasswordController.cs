using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.DTOs;
using Portfolio.Application.Interfaces;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResetPasswordController : ControllerBase
    {
        private readonly IAuthService _authService;
        public ResetPasswordController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("forgot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email))
            {
                return BadRequest("Email is required.");
            }
            await _authService.SendResetPasswordTokenAsync(request);
            return Ok("Reset password token sent to your email.");
        }

        [HttpPost("reset")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.OTP) || string.IsNullOrEmpty(request.NewPassword))
            {
                return BadRequest("Token and new password are required.");
            }
            await _authService.ResetUserPasswordAsync(request);
            return Ok("Password has been reset successfully.");
        }
    }
}
