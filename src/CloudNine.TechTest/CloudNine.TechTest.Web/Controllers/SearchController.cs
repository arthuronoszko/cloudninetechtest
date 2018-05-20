using System.Web.Mvc;

namespace CloudNine.TechTest.Web.Controllers {
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search() {
            return PartialView("SearchResults");
        }
    }
}