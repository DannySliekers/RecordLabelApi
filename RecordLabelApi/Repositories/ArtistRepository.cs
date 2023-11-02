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

        public IQueryable<Artist> Get(int id)
        {
            return from artist in _context.Artists where artist.Id == id select artist;
        }

        public IQueryable<Artist> GetAll()
        {
            return from artist in _context.Artists select artist;
        }
    }
}
