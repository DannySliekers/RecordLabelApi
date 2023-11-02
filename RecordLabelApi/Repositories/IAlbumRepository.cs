using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        Album Get(int id);
        Task<int> AddAlbum(Album album);
        Task<int> UpdateAlbum(Album album);
        Task<int> DeleteAlbum(int id);
    }
}
