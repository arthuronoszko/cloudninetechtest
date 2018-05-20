using Newtonsoft.Json;

namespace CloudNine.TechTest.Service.Spotify.Response {
    public class SpotifyTrackResponseModel {

        [JsonProperty("href")]
        public string Link { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}