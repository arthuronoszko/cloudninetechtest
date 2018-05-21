using Newtonsoft.Json;

namespace CloudNine.TechTest.Service.Spotify.Api.Response {
    public class SpotifyTrackAudioFeatureResponseModel {
        [JsonProperty("id")]
        public string TrackId { get; set; }
        [JsonProperty("danceability")]
        public float Danceability { get; set; }
    }
}