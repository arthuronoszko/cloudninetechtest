using System.ComponentModel.DataAnnotations;

namespace CloudNine.TechTest.Web.ViewModels {
    public class SearchViewModel {
        public DanceabilityScore Danceability { get; set; }
        public Genre Genre { get; set; }
    }

    public enum Genre {
        [Display(Name = "Hip hop")]
        HipHop,
        [Display(Name = "Rock")]
        Rock,
        [Display(Name = "Klassiskt")]
        Classical,
        [Display(Name = "Elektroniskt")]
        Electronic
    }
}