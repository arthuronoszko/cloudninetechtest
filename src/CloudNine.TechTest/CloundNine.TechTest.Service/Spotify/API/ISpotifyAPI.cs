using CloudNine.TechTest.Service.Spotify.Api.Response;
using System.Threading.Tasks;

namespace CloudNine.TechTest.Service.Spotify.Api {
    public interface ISpotifyAPI {
        Task<SpotifyTracksResponseModel> SearchGenreAsync(string genreName);
    }
}