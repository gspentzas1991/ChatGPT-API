using Microsoft.AspNetCore.Mvc;
using OpenAIApi.Models;
using OpenAIApi.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenAIApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [SwaggerTag("Endpoints for the ChatGPT chat model")]
    public class ChatController : ControllerBase
    {
        private readonly ILogger<ChatController> _logger;
        private readonly IAIService _openAIService;

        public ChatController(ILogger<ChatController> logger, IAIService completionService)
        {
            _logger = logger;
            _openAIService = completionService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCompletionFromPrompt(string prompt)
        {
            try
            {
                var response = await _openAIService.GetChatResponseAsync(prompt);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("FromRequest")]
        public async Task<IActionResult> GetCompletionFromRequest(ChatRequest request)
        {
            try
            {
                var response = await _openAIService.GetChatResponseAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}