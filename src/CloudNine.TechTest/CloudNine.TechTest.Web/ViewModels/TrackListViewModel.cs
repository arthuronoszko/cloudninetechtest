using CloudNine.TechTest.Service.Spotify.Api.Response;
using System.Linq;

namespace CloudNine.TechTest.Web.ViewModels {
    public class TrackListViewModel {
        public string Name { get; set; }
        public string ListeningLink { get; set; }
        public string Artists { get; set; }
    }

    public static class SpotifyTrackResponseModelExtensions {
        public static TrackListViewModel ToListViewModel(this SpotifyTrackResponseModel model) {
            return new TrackListViewModel {
                Name = model.Name,
                ListeningLink = model.Uri,
                Artists = string.Join(" - ", model.Artists.Select(x => x.Name))
            };
        }
    }
}