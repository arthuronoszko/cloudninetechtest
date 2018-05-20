using System.Threading.Tasks;
using CloudNine.TechTest.Service.Spotify.Response;

namespace CloudNine.TechTest.Service.Spotify {
    public interface ISpotifyService {
        Task<SpotifyTracksResponseModel> SearchGenreAsync(string genreName);
    }
}