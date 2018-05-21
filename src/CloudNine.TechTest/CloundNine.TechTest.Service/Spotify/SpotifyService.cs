using CloudNine.TechTest.Service.Spotify.Api;
using CloudNine.TechTest.Service.Spotify.Api.Response;
using CloudNine.TechTest.Service.Spotify.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNine.TechTest.Service.Spotify {
    public class SpotifyService : ISpotifyService {
        private readonly ISpotifyAPI _api;
        public SpotifyService(ISpotifyAPI api) {
            _api = api;
        }

        public async Task<IEnumerable<SpotifyTrack>> SearchTracksAsync(string genreName) {
            var tracksResponse = await _api.SearchGenreAsync(genreName);
            var tracks = tracksResponse.Tracks.Items;
            var trackIds = tracks.Select(x => x.Id);
            var audioFeaturesResponse = await _api.GetAudioFeaturesAsync(trackIds);
            var spotifyTracks = tracks.Select(x => ToSpotifyTrack(x, audioFeaturesResponse.AudioFeatures));
            return spotifyTracks;
        }

        private static SpotifyTrack ToSpotifyTrack(SpotifyTrackResponseModel track, IEnumerable<SpotifyTrackAudioFeatureResponseModel> audioFeatures) {
            var audioFeatureForTrack = audioFeatures.FirstOrDefault(x => x.TrackId == track.Id);
            return new SpotifyTrack() {
                Name = track.Name,
                ListeningURL = track.Uri,
                Artists = track.Artists.Select(x => x.ToTrackArtist()),
                DanceabilityValue = audioFeatureForTrack?.Danceability ?? 0
            };
        }
    }
}