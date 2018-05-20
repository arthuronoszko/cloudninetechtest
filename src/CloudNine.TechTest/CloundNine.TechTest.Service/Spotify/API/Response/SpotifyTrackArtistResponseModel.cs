using Newtonsoft.Json;

namespace CloudNine.TechTest.Service.Spotify.Api.Response {
    public class SpotifyTrackArtistResponseModel {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}