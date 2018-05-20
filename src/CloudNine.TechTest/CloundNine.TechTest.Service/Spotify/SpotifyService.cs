using CloudNine.TechTest.Service.Oauth;
using CloudNine.TechTest.Service.Spotify.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CloudNine.TechTest.Service.Spotify {
    public class SpotifyService {

        private HttpClient _httpClient;
        private readonly string _spotifyApiBaseAddress = "https://api.spotify.com/";
        private readonly string _spotifyAuthenticationEndpoint = "https://accounts.spotify.com/api/token";
        private readonly string _spotifyClientId = "eff46989a68d4235a5dd72bdc40fd439";
        private readonly string _spotifyClientSecret = "b95fb3814a1c4f2f8958573ec57d6555";

        public SpotifyService() {
            var oauthMessageHandler = new OauthMessageHandler(
                authenticationEndpoint: _spotifyAuthenticationEndpoint,
                clientId: _spotifyClientId,
                clientSecret: _spotifyClientSecret,
                baseMessageHandler: new HttpClientHandler()
                );

            _httpClient = new HttpClient(oauthMessageHandler) {
                BaseAddress = new Uri(_spotifyApiBaseAddress),
            };
        }

        public async Task<SpotifyTracksResponseModel> SearchGenreAsync(string genreName) {

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["q"] = $"genre:{genreName}";
            query["type"] = "track";

            var path = $"v1/search?{query.ToString()}";

            var result = await _httpClient.GetStringAsync(path);
            var tracksResponse = JsonConvert.DeserializeObject<SpotifyTracksResponseModel>(result);
            return tracksResponse;
        }
    }
}