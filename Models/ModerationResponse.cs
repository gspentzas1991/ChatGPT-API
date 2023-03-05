using Newtonsoft.Json;

namespace OpenAIApi.Models
{
    public class ModerationResponse
    {
        public string id { get; set; } 
        public string model { get; set; }
        public IEnumerable<ModerationResult> results { get; set; }
    }

    public class ModerationResult
    {
        public bool flagged { get; set; }
        public ModerationCategories categories { get; set; }
        public ModerationCategoryScores category_scores { get; set; }
    }

    public class ModerationCategories
    {
        public bool sexual { get; set; }
        public bool hate { get; set; }
        public bool violence { get; set; }
        [JsonProperty(PropertyName = "self-harm")]
        public bool self_harm { get; set; }
        [JsonProperty(PropertyName = "sexual/minors")]
        public bool sexual_minors { get; set; }
        [JsonProperty(PropertyName = "hate/threatening")]
        public bool hate_threatening { get; set; }
        [JsonProperty(PropertyName = "violence/graphic")]
        public bool violence_graphic { get; set; }
    }

    public class ModerationCategoryScores
    {
        public double sexual { get; set; }
        public float hate { get; set; }
        public float violence { get; set; }
        [JsonProperty(PropertyName = "self-harm")]
        public float self_harm { get; set; }
        [JsonProperty(PropertyName = "sexual/minors")]
        public float sexual_minors { get; set; }
        [JsonProperty(PropertyName = "hate/threatening")]
        public float hate_threatening { get; set; }
        [JsonProperty(PropertyName = "violence/graphic")]
        public float violence_graphic { get; set; }
    }

}
