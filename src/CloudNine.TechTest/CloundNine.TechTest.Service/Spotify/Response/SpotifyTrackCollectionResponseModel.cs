using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudNine.TechTest.Service.Spotify.Response {
    public class SpotifyTrackCollectionResponseModel {
        [JsonProperty("items")]
        public IEnumerable<SpotifyTrackResponseModel> Items { get; set;}
    }
}