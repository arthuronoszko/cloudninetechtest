using System.Collections.Generic;

namespace CloudNine.TechTest.Web.ViewModels {
    public class SearchResultsViewModel {
        public IEnumerable<TrackListViewModel> Tracks;

        public SearchResultsViewModel(IEnumerable<TrackListViewModel> tracks) {
            Tracks = tracks ?? new List<TrackListViewModel>();
        }
    }
}