using Dapper;
using RecordLabelApi.Context;
using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly RecordLabelContext _context;
        public ArtistRepository(RecordLabelContext context)
        {
            _context = context;
        }

        public async Task<int> AddArtist(Artist artist)
        {
            _context.Artist.Add(artist);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteArtist(int id)
        {
            var artist = _context.Artist.FirstOrDefault(a => a.id == id);
            _context.Artist.Remove(artist);
            return await _context.SaveChangesAsync();
        }

        public Artist Get(int id)
        {
            return _context.Artist.Find(id);
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artist.ToList();
        }

        public async Task<int> UpdateArtist(Artist artist)
        {
            _context.Artist.Update(artist);
            return await _context.SaveChangesAsync();
        }
    }
}
