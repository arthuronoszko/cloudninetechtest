using CloudNine.TechTest.Service.Spotify.Api;
using CloudNine.TechTest.Service.Spotify.Api.Response;
using System.Threading.Tasks;

namespace CloudNine.TechTest.Service.Spotify {
    public class SpotifyService : ISpotifyService {
        private readonly ISpotifyAPI _api;
        public SpotifyService(ISpotifyAPI api) {
            _api = api;
        }

        public async Task<SpotifyTracksResponseModel> SearchGenreAsync(string genreName) {
            return await _api.SearchGenreAsync(genreName);
        }
    }
}