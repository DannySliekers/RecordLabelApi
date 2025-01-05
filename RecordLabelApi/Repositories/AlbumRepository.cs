using RecordLabelApi.Context;
using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordLabelContext _context;

        public AlbumRepository(RecordLabelContext context)
        {
            _context = context;
        }

        public async Task<int> AddAlbum(Album album)
        {
            _context.Album.Add(album);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAlbum(int id)
        {
            var album = _context.Album.FirstOrDefault(a => a.Id == id);
            _context.Album.Remove(album);
            return await _context.SaveChangesAsync();
        }

        public Album Get(int id)
        {
            return _context.Album.Find(id);
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Album.ToList();
        }

        public async Task<int> UpdateAlbum(Album album)
        {
            _context.Album.Update(album);
            return await _context.SaveChangesAsync();
        }
    }
}
