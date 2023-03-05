using System.ComponentModel;

namespace OpenAIApi.Models
{
    public class CompletionRequest
    {
        [DefaultValue("text-davinci-003")]
        public string model { get; set; }
        [DefaultValue("Hello World")]
        public string prompt { get; set; }
        [DefaultValue(0.9)]
        public double temperature { get; set; }
        [DefaultValue(150)]
        public int max_tokens { get; set; }
        [DefaultValue(1)]
        public int top_p { get; set; }
        [DefaultValue(0)]
        public int frequency_penalty { get; set; }
        [DefaultValue(0.6)]
        public double presence_penalty { get; set; }
        [DefaultValue(null)]
        public List<string>? stop { get; set; }

    }
}
