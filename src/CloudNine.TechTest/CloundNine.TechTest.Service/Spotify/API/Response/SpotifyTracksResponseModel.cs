using Newtonsoft.Json;

namespace CloudNine.TechTest.Service.Spotify.Api.Response {
    public class SpotifyTracksResponseModel {
        [JsonProperty("tracks")]
        public SpotifyTrackCollectionResponseModel Tracks { get; set; }
    }
}