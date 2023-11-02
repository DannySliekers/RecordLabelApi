using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IAlbumRepository
    {
        IQueryable<Album> GetAll();
        IQueryable<Album> Get(int id);
        Task<int> AddAlbum(Album album);
        Task<int> UpdateAlbum(Album album);
        Task<int> DeleteAlbum(int id);
    }
}
