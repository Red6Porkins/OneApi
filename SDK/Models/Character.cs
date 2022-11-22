using Newtonsoft.Json;

namespace SDK.Models
{
    [Serializable]
    public class Character
    {
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "height")]
        public string? Height { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string? Gender { get; set; }

        [JsonProperty(PropertyName = "birth")]
        public string? Birth { get; set; }

        [JsonProperty(PropertyName = "spouse")]
        public string? Spouse { get; set; }

        [JsonProperty(PropertyName = "death")]
        public string? Death { get; set; }

        [JsonProperty(PropertyName = "realm")]
        public string? Realm { get; set; }

        [JsonProperty(PropertyName = "hair")]
        public string? Hair { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "wikiUrl")]
        public string? WikiUrl { get; set; }
    }
}
