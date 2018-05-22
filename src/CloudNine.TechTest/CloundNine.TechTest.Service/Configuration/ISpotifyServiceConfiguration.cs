namespace CloundNine.TechTest.Service.Configuration {
    public interface ISpotifyServiceConfiguration {
        string SpotifyClientID { get; }
        string SpotifyClientSecret { get; }
        string SpotifyBaseURL { get; }
        string SpotifyAuthenticationEndpoint { get; }
    }
}