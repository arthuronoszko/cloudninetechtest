using System.Web.Optimization;

namespace CloudNine.TechTest.Web {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                    .Include("~/Scripts/jquery-{version}.js")
                    .Include("~/Scripts/jquery.unobtrusive*"));
        }
    }
}