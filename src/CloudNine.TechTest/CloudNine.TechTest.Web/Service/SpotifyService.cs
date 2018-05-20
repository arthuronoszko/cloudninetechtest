using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CloudNine.TechTest.Web.Service {
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
            query["q"] = genreName;
            query["type"] = "track";

            var path = $"v1/search?{query.ToString()}";

            var result = await _httpClient.GetStringAsync(path);
            var tracksResponse = JsonConvert.DeserializeObject<SpotifyTracksResponseModel>(result);
            return tracksResponse;
        }

    }

    public class SpotifyTracksResponseModel {
        [JsonProperty("tracks")]
        public SpotifyTrackCollectionResponseModel Tracks { get; set; }
    }

    public class SpotifyTrackCollectionResponseModel {
        [JsonProperty("items")]
        public IEnumerable<SpotifyTrackResponseModel> Items { get; set;}
    }
    public class SpotifyTrackResponseModel {

        [JsonProperty("href")]
        public string Link { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}