using Newtonsoft.Json;

namespace CloudNine.TechTest.Service.Spotify.Response {
    public class SpotifyTracksResponseModel {
        [JsonProperty("tracks")]
        public SpotifyTrackCollectionResponseModel Tracks { get; set; }
    }
}