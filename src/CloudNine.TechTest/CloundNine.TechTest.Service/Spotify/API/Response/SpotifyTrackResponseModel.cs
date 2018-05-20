using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudNine.TechTest.Service.Spotify.Api.Response {
    public class SpotifyTrackResponseModel {

        [JsonProperty("href")]
        public string Link { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
        [JsonProperty("artists")]
        public IEnumerable<SpotifyTrackArtistResponseModel> Artists { get; set; }

    }
}