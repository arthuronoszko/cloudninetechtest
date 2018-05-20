using CloudNine.TechTest.Service.Spotify;
using CloundNine.TechTest.Service.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CloudNine.TechTest.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<ISpotifyService, SpotifyService>();
            container.RegisterType<ISpotifyServiceConfiguration, ServiceConfiguration>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}