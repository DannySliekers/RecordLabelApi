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
            _context.Artists.Add(artist);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteArtist(int id)
        {
            var artist = _context.Artists.FirstOrDefault(a => a.Id == id);
            _context.Artists.Remove(artist);
            return await _context.SaveChangesAsync();
        }

        public Artist Get(int id)
        {
            return _context.Artists.Find(id);
        }

        public IEnumerable<Artist> GetAll()
        {
            return _context.Artists.ToList();
        }

        public async Task<int> UpdateArtist(Artist artist)
        {
            _context.Artists.Update(artist);
            return await _context.SaveChangesAsync();
        }
    }
}
