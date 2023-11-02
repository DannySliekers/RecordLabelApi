using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAll();
        Artist Get(int id);
        Task<int> AddArtist(Artist artist);
        Task<int> UpdateArtist(Artist artist);
        Task<int> DeleteArtist(int id);
    }
}
