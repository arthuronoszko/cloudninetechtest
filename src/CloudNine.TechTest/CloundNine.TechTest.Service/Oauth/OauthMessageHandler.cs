using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using System.Text;

namespace CloudNine.TechTest.Service.Oauth {
    internal class OauthMessageHandler : DelegatingHandler {
        private readonly string _authenticationEndpoint;
        private readonly string _clientId;
        private readonly string _clientSecret;

        internal OauthMessageHandler(string authenticationEndpoint, string clientId, string clientSecret, HttpMessageHandler baseMessageHandler) : base(baseMessageHandler) {
            _authenticationEndpoint = authenticationEndpoint;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            if (request.Headers.Authorization == null) {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await GetAuthenticationTokenAsync());
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private async Task<string> GetAuthenticationTokenAsync() {
            var cacheKey = $"{_authenticationEndpoint}:{_clientId}:{_clientSecret}";
            var token = MemoryCache.Default.Get(cacheKey) as string;

            if (token == null) {
                var now = DateTime.Now;
                var response = await GetAuthenticationTokenResponseAsync();
                token = response?.AccessToken;
                if (token == null)
                    throw new AuthenticationException("Authentication failed");

                var expireTime = now.AddSeconds(response.ExpiresIn);
                MemoryCache.Default.Set(cacheKey, token, new DateTimeOffset(expireTime));
            }
            return token;
        }

        private async Task<OauthAuthenticationResponse> GetAuthenticationTokenResponseAsync() {
            var client = new HttpClient();

            var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var authHeader = AuthHeader();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, _authenticationEndpoint);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
            requestMessage.Content = content;

            var response = await client.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();

            var authenticationResponse = JsonConvert.DeserializeObject<OauthAuthenticationResponse>(responseString);
            return authenticationResponse;
        }

        private string AuthHeader() {
            var authHeaderValue = $"{_clientId}:{_clientSecret}";
            var bytes = Encoding.UTF8.GetBytes(authHeaderValue);
            return Convert.ToBase64String(bytes);
        }

        private class OauthAuthenticationResponse {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
        }
    }
}