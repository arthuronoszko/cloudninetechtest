namespace CloundNine.TechTest.Service.Configuration {
    public class ServiceConfiguration : ISpotifyServiceConfiguration {
        public string SpotifyBaseURL => "https://api.spotify.com/";
        public string SpotifyClientID => "eff46989a68d4235a5dd72bdc40fd439";
        public string SpotifyClientSecret => "b95fb3814a1c4f2f8958573ec57d6555";
        public string SpotifyAuthenticationEndpoint => "https://accounts.spotify.com/api/token";
    }
}
