using CloudNine.TechTest.Web.Models;
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
        public ActionResult Search(SearchViewModel model) {

            var resultsViewModel = new SearchResultsViewModel();
            resultsViewModel.GenreSearchString = model.GenreSearchString;

            return PartialView("SearchResults", resultsViewModel);
        }
    }
}