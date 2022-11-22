using Newtonsoft.Json;

namespace SDK.Models
{
    [Serializable]
    public class Chapter
    {
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "chapterName")]
        public string? ChapterName { get; set; }
    }
}
