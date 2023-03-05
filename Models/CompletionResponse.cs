using Newtonsoft.Json;

namespace OpenAIApi.Models
{
    public class CompletionResponse
    {
        public string id { get; set; }
        [JsonProperty(PropertyName = "object")]
        public string objectResponse { get; set; }
        public string created { get; set; }
        public string model { get; set; }
        public IEnumerable<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }

    public class Choice
    {
        public ChatMessage message { get; set; }
        public string text { get; set; }
        public int index { get; set; }
        public string logProbs { get; set; }
        public string finish_reason { get; set; }
    }

    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}
