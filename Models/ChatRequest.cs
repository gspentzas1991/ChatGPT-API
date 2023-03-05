using System.ComponentModel;

namespace OpenAIApi.Models
{
    public enum ChatRole
    {
        system = 0,
        user = 1,
        assistant = 2
    }
    public class ChatRequest
    {
        [DefaultValue("gpt-3.5-turbo")]
        public string model { get; set; }
        public List<ChatMessage> messages { get; set; }
    }

    public class ChatMessage
    {
        [DefaultValue("system")]
        public string role { get; set; }
        [DefaultValue("This is an AI assistant")]
        public string content { get; set; }
    }
}
