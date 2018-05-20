using CloudNine.TechTest.Web.Models;
using CloudNine.TechTest.Web.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudNine.TechTest.Web.Controllers {
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View(new SearchViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Search(SearchViewModel model) {
            var trackNames = new List<string>();
            var spotifyService = new SpotifyService();
            var tracksResponse = await spotifyService.SearchGenreAsync(model.GenreSearchString);
            trackNames = tracksResponse.Tracks.Items.Select(x => x.Name).ToList();

            var resultsViewModel = new SearchResultsViewModel(genreSearchString: model.GenreSearchString, trackNames: trackNames);
            return PartialView("SearchResults", resultsViewModel);
        }
    }
}