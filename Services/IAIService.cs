using OpenAIApi.Models;

namespace OpenAIApi.Services
{
    public interface IAIService
    {
        /// <summary>
        /// Sends a completion request based on the provided prompt, and returns the completion response from the OpenAI API
        /// </summary>
        Task<CompletionResponse> GetCompletionResponseAsync(string prompt);
        Task<CompletionResponse> GetCompletionResponseAsync(CompletionRequest request);
        /// <summary>
        /// Sends a chat request based on the provided prompt, and returns the chat response from the OpenAI API
        /// </summary>
        Task<CompletionResponse> GetChatResponseAsync(string prompt);
        Task<CompletionResponse> GetChatResponseAsync(ChatRequest request);
        /// <summary>
        /// Sends a content moderation request to get information on the provided input, and returns the result
        /// </summary>
        Task<ModerationResponse> GetModerationResponseAsync(string input);

    }
}
