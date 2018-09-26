using Newtonsoft.Json;

namespace csharp_and_the_strava_web_api
{
    public class Athlete
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("resource_state")]
        public int? ResourceState { get; set; }

        [JsonProperty("profile_medium")]
        public string ProfileMedium { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }
}