using Newtonsoft.Json;

namespace SDK.Models
{
    [Serializable]
    public class Quote
    {
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public string? Movie { get; set; }

        [JsonProperty(PropertyName = "character")]
        public string? Character { get; set; }

        [JsonProperty(PropertyName = "dialog")]
        public string? Dialog { get; set; }
    }
}
