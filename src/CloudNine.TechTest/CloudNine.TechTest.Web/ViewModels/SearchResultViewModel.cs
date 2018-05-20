using System.Collections.Generic;

namespace CloudNine.TechTest.Web.ViewModels {
    public class SearchResultsViewModel {
        public string GenreSearchString;
        public IEnumerable<TrackListViewModel> Tracks;

        public SearchResultsViewModel(string genreSearchString, IEnumerable<TrackListViewModel> tracks) {
            GenreSearchString = genreSearchString;
            Tracks = tracks ?? new List<TrackListViewModel>();
        }
    }
}