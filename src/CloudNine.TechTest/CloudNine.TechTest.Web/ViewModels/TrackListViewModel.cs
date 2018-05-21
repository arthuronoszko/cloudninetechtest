using CloudNine.TechTest.Service.Spotify;
using CloudNine.TechTest.Service.Spotify.Model;
using System.Linq;

namespace CloudNine.TechTest.Web.ViewModels {

    public class TrackListViewModel {
        public string Name { get; set; }
        public string ListeningLink { get; set; }
        public string Artists { get; set; }
        public DanceabilityScore DanceabilityScore { get; set; }
    }
    public enum DanceabilityScore {
        Low,
        Medium,
        High
    }

    public static class SpotifyTrackExtensions {
        public static TrackListViewModel ToListViewModel(this SpotifyTrack model) {
            return new TrackListViewModel {
                Name = model.Name,
                ListeningLink = model.ListeningURL,
                Artists = string.Join(" - ", model.Artists.Select(x => x.Name)),
                DanceabilityScore = CalculateScore(model.DanceabilityValue)
            };
        }

        private static DanceabilityScore CalculateScore(float danceabilityValue) {
            if (danceabilityValue <= 1f / 5f) {
                return DanceabilityScore.Low;
            }
            if (danceabilityValue < 4f / 5f) {
                return DanceabilityScore.Medium;
            }

            return DanceabilityScore.High;
        }
    }
}