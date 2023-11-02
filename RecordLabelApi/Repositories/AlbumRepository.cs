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
            _context.Albums.Add(album);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.Id == id);
            _context.Albums.Remove(album);
            return await _context.SaveChangesAsync();
        }

        public Album Get(int id)
        {
            return _context.Albums.Find(id);
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.Albums.ToList();
        }

        public async Task<int> UpdateAlbum(Album album)
        {
            _context.Albums.Update(album);
            return await _context.SaveChangesAsync();
        }
    }
}
