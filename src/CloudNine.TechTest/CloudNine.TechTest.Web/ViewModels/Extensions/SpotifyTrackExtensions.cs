using CloudNine.TechTest.Service.Spotify.Model;
using System.Linq;

namespace CloudNine.TechTest.Web.ViewModels {
    static class SpotifyTrackExtensions {
        public static TrackListViewModel ToListViewModel(this SpotifyTrack model) {
            return new TrackListViewModel {
                Name = model.Name,
                ListeningLink = model.ListeningURL,
                Artists = string.Join(" - ", model.Artists.Select(x => x.Name)),
                DanceabilityScore = CalculateScore(model.DanceabilityValue)
            };
        }

        private static DanceabilityScore CalculateScore(float danceabilityValue) {
            if (danceabilityValue <= 1f / 3f) {
                return DanceabilityScore.Low;
            }
            if (danceabilityValue <= 2f / 3f) {
                return DanceabilityScore.Medium;
            }

            return DanceabilityScore.High;
        }
    }
}