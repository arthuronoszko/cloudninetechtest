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
            var tracksResponse = await _spotifyService.SearchGenreAsync(model.GenreSearchString);
            var tracks = tracksResponse.Tracks.Items.Select(x => x.ToListViewModel());
            var resultsViewModel = new SearchResultsViewModel(genreSearchString: model.GenreSearchString, tracks: tracks);
            return PartialView("SearchResults", resultsViewModel);
        }
    }
}