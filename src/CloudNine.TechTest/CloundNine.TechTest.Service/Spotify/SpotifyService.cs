using CloudNine.TechTest.Service.Oauth;
using CloudNine.TechTest.Service.Spotify.Response;
using CloundNine.TechTest.Service.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CloudNine.TechTest.Service.Spotify {
    public class SpotifyService : ISpotifyService {

        private HttpClient _httpClient;

        public SpotifyService(ISpotifyServiceConfiguration configuration) {

            var oauthMessageHandler = new OauthMessageHandler(
                authenticationEndpoint: configuration.SpotifyAuthenticationEndpoint,
                clientId: configuration.SpotifyClientID,
                clientSecret: configuration.SpotifyClientSecret,
                baseMessageHandler: new HttpClientHandler()
                );

            _httpClient = new HttpClient(oauthMessageHandler) {
                BaseAddress = new Uri(configuration.SpotifyBaseURL),
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