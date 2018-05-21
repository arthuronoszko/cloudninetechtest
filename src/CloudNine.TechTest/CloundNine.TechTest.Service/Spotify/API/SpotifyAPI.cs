using CloudNine.TechTest.Service.Oauth;
using CloudNine.TechTest.Service.Spotify.Api.Response;
using CloundNine.TechTest.Service.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CloudNine.TechTest.Service.Spotify.Api {
    public class SpotifyAPI : ISpotifyAPI {
        private readonly HttpClient _httpClient;
        public SpotifyAPI(ISpotifyServiceConfiguration configuration) {
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
            query["limit"] = "50";

            var path = $"v1/search?{query.ToString()}";

            var result = await _httpClient.GetStringAsync(path);
            var tracksResponse = JsonConvert.DeserializeObject<SpotifyTracksResponseModel>(result);
            return tracksResponse;
        }

        public async Task<SpotifyTrackAudioFeaturesResponseCollectionResponseModel> GetAudioFeaturesAsync(IEnumerable<string> trackIds) {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["ids"] = string.Join(",", trackIds);

            var path = $"v1/audio-features?{query.ToString()}";

            var result = await _httpClient.GetStringAsync(path);
            var audioFeaturesResponse = JsonConvert.DeserializeObject<SpotifyTrackAudioFeaturesResponseCollectionResponseModel>(result);
            return audioFeaturesResponse;
        }
    }
}