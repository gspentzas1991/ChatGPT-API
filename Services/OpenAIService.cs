using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace OpenAIApi.Models.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly string? _apiKey;
        private readonly ILogger<OpenAIService> _logger;

        public OpenAIService(ILogger<OpenAIService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _apiKey = configuration["ApiKey"];
        }

        public async Task<CompletionResponse> GetCompletionResponseAsync(CompletionRequest request)
        {
            using (var client = GetHttpClient())
            {
                return await SendHttpReequestAsync<CompletionResponse>(client, "https://api.openai.com/v1/completions", request);
            }
        }

        public async Task<CompletionResponse> GetCompletionResponseAsync(string prompt)
        {
            using (var client = GetHttpClient())
            {
                var request = GetDefaultRequest(prompt);
                return await SendHttpReequestAsync<CompletionResponse>(client, "https://api.openai.com/v1/completions", request);
            }
        }
        public async Task<CompletionResponse> GetChatResponseAsync(ChatRequest request)
        {
            using (var client = GetHttpClient())
            {
                return await SendHttpReequestAsync<CompletionResponse>(client, "https://api.openai.com/v1/chat/completions", request);
            }
        }

        public async Task<CompletionResponse> GetChatResponseAsync(string prompt)
        {
            using (var client = GetHttpClient())
            {
                var request = GetDefaultChatRequest(prompt);
                return await SendHttpReequestAsync<CompletionResponse>(client, "https://api.openai.com/v1/chat/completions", request);
            }
        }

        public async Task<ModerationResponse> GetModerationResponseAsync(string input)
        {
            using (var client = GetHttpClient())
            {
                var request = new ModerationRequest { input = input };
                return await SendHttpReequestAsync<ModerationResponse>(client, "https://api.openai.com/v1/moderations", request);
            }
        }

        private async Task<T> SendHttpReequestAsync<T>(HttpClient client, string url, object body)
        {
            var httpResponse = await client.PostAsJsonAsync(url, body);
            if (!httpResponse.IsSuccessStatusCode)
            {
                var errorMessage = await httpResponse.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
            return await httpResponse.Content.ReadAsAsync<T>();
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            return client;
        }

        private CompletionRequest GetDefaultRequest(string prompt)
        {
            var data = new CompletionRequest()
            {
                model = "text-davinci-003",
                prompt = prompt,
                temperature = 0.9,
                max_tokens = 150,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0.6,
                stop = new List<string>() { }
            };
            return data;
        }

        private ChatRequest GetDefaultChatRequest(string prompt)
        {
            var data = new ChatRequest()
            {
                model = "gpt-3.5-turbo",
                messages = new List<ChatMessage>()
                {
                    new ChatMessage()
                    {
                        role = "system",
                        content = "This is an AI assistant"
                    },
                    new ChatMessage()
                    {
                        role = "user",
                        content = prompt
                    }
                }
            };
            return data;
        }
    }
}
