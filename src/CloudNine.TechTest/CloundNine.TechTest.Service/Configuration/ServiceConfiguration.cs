using System.Configuration;

namespace CloundNine.TechTest.Service.Configuration {
    public class ServiceConfiguration : ISpotifyServiceConfiguration {
        public string SpotifyBaseURL => ConfigurationManager.AppSettings["SpotifyBaseURL"];
        public string SpotifyClientID => ConfigurationManager.AppSettings["SpotifyClientID"];
        public string SpotifyClientSecret => ConfigurationManager.AppSettings["SpotifyClientSecret"];
        public string SpotifyAuthenticationEndpoint => ConfigurationManager.AppSettings["SpotifyAuthenticationEndpoint"];
    }
}
