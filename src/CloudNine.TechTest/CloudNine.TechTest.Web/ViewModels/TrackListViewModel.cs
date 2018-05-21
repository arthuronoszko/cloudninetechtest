using System.ComponentModel.DataAnnotations;

namespace CloudNine.TechTest.Web.ViewModels {

    public class TrackListViewModel {
        public string Name { get; set; }
        public string ListeningLink { get; set; }
        public string Artists { get; set; }
        public DanceabilityScore DanceabilityScore { get; set; }
    }

    public enum DanceabilityScore {
        [Display(Name = "Mycket")]
        High,
        [Display(Name = "Lagom")]
        Medium,
        [Display(Name = "Inte alls")]
        Low
    }
}