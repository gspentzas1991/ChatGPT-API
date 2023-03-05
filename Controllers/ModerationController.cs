using Microsoft.AspNetCore.Mvc;
using OpenAIApi.Models;
using OpenAIApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenAIApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Endpoints for the content moderation model")]
    public class ModerationController : ControllerBase
    {
        private readonly ILogger<ModerationController> _logger;
        private readonly IAIService _openAIService;

        public ModerationController(ILogger<ModerationController> logger, IAIService completionService)
        {
            _logger = logger;
            _openAIService = completionService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompletionFromPrompt(string prompt)
        {
            try
            {
                var response = await _openAIService.GetModerationResponseAsync(prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}