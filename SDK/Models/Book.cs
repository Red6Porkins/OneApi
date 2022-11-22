using Newtonsoft.Json;

namespace SDK.Models
{
    [Serializable]
    public class Book
    {
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }
    }
}
