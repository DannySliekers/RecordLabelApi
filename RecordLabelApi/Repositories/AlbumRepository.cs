using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        public Task<int> AddAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAlbum(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAlbum(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
