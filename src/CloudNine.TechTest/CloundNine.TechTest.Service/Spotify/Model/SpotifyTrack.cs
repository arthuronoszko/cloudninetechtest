using CloudNine.TechTest.Service.Spotify.Api.Response;
using System.Collections.Generic;

namespace CloudNine.TechTest.Service.Spotify.Model {
    public class SpotifyTrack {
        public string Name { get; set; }
        public string ListeningURL { get; set; }
        public IEnumerable<SpotifyTrackArtist> Artists { get; set; }
        public float DanceabilityValue { get; set; }
    }

    public class SpotifyTrackArtist {
        public string Name { get; set; }
    }

    public static class SpotifyTrackArtistResponseModelExtensions {
        public static SpotifyTrackArtist ToTrackArtist(this SpotifyTrackArtistResponseModel responseModel) {
            return new SpotifyTrackArtist() {
                Name = responseModel.Name
            };
        }
    }
}