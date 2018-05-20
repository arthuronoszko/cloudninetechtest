using System.Collections.Generic;

namespace CloudNine.TechTest.Web.Models {
    public class SearchResultsViewModel {
        public string GenreSearchString;
        public IEnumerable<string> TrackNames;

        public SearchResultsViewModel(string genreSearchString, IEnumerable<string> trackNames) {
            GenreSearchString = genreSearchString;
            TrackNames = trackNames ?? new List<string>();
        }
    }
}