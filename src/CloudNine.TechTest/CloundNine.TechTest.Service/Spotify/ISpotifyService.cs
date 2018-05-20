using System.Threading.Tasks;
using CloudNine.TechTest.Service.Spotify.Api.Response;

namespace CloudNine.TechTest.Service.Spotify {
    public interface ISpotifyService {
        Task<SpotifyTracksResponseModel> SearchGenreAsync(string genreName);
    }
}