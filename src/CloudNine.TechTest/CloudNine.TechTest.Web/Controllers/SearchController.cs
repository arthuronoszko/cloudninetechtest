using CloudNine.TechTest.Service.Spotify;
using CloudNine.TechTest.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudNine.TechTest.Web.Controllers {
    public class SearchController : Controller {
        private readonly ISpotifyService _spotifyService;

        public SearchController(ISpotifyService spotifyService) {
            _spotifyService = spotifyService;
        }
        
        public ActionResult Index() {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Search(SearchViewModel model) {
            var genreSearchName = SearchName(model.Genre);
            var tracksResponse = await _spotifyService.SearchTracksAsync(genreSearchName);

            var tracks = tracksResponse.Select(x => x.ToListViewModel()).Where(x => x.DanceabilityScore == model.Danceability);
            var resultsViewModel = new SearchResultsViewModel(tracks: tracks);
            return PartialView("SearchResults", resultsViewModel);
        }

        private string SearchName(Genre genre) {
            switch (genre) {
                case Genre.Classical: return "classical";
                case Genre.Electronic: return "electronic";
                case Genre.HipHop: return "hip-hop";
                case Genre.Rock: return "rock";
                case Genre.Disco: return "disco";
                case Genre.Pop: return "pop";
                case Genre.Dance: return "dance";
                default: return "";
            }
        }
    }
}