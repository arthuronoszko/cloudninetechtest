using CloudNine.TechTest.Service.Spotify.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudNine.TechTest.Service.Spotify {
    public interface ISpotifyService {
        Task<IEnumerable<SpotifyTrack>> SearchTracksAsync(string genreName);
    }
}