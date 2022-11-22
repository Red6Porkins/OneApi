using Newtonsoft.Json;

namespace SDK.Models
{
    [Serializable]
    public class Movie
    {
        [JsonProperty(PropertyName = "_id")]
        public string? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "runTimeInMinutes")]
        public int RunTimeInMinutes { get; set; }

        [JsonProperty(PropertyName = "boxOfficeRevenueInMillions")]
        public int BoxOfficeRevenueInMillions { get; set; }

        [JsonProperty(PropertyName = "academyAwardNominations")]
        public int AcademyAwardNominations { get; set; }

        [JsonProperty(PropertyName = "academyAwardWins")]
        public int AcademyAwardWins { get; set; }

        [JsonProperty(PropertyName = "rottenTomatoesScore")]
        public int RottenTomatoesScore { get; set; }
    }
}
