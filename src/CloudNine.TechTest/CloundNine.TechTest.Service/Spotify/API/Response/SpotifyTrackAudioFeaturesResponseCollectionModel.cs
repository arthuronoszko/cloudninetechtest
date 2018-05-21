using Newtonsoft.Json;
using System.Collections.Generic;

namespace CloudNine.TechTest.Service.Spotify.Api.Response {
    public class SpotifyTrackAudioFeaturesResponseCollectionResponseModel {
        [JsonProperty("audio_features")]
        public IEnumerable<SpotifyTrackAudioFeatureResponseModel> AudioFeatures { get; set; }   
    }
}