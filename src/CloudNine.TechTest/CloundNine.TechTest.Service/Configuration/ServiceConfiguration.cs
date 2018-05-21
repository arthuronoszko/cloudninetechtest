namespace CloundNine.TechTest.Service.Configuration {
    public class ServiceConfiguration : ISpotifyServiceConfiguration {
        public string SpotifyBaseURL => "https://api.spotify.com/";
        public string SpotifyClientID => "996d0037680544c987287a9b0470fdbb";
        public string SpotifyClientSecret => "5a3c92099a324b8f9e45d77e919fec13";
        public string SpotifyAuthenticationEndpoint => "https://accounts.spotify.com/api/token";
    }
}
