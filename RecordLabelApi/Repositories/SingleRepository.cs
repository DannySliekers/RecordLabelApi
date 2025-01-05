using RecordLabelApi.Context;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Repositories
{
    public class SingleRepository : ISingleRepository
    {
        private readonly RecordLabelContext _context;

        public SingleRepository(RecordLabelContext context)
        {
            _context = context;
        }

        public async Task<int> AddSingle(Single single)
        {
            _context.Single.Add(single);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSingle(int id)
        {
            var single = _context.Single.FirstOrDefault(s => s.id == id);
            _context.Single.Remove(single);
            return await _context.SaveChangesAsync();
        }

        public Single Get(int id)
        {
            return _context.Single.Find(id);
        }

        public IEnumerable<Single> GetAll()
        {
            return _context.Single.ToList();
        }

        public IEnumerable<Single> GetByArtistId(int artistId)
        {
            var artist = _context.Artist.Find(artistId);
            var singles = _context.Single.Where(single => single.artistid == artistId).ToList();
            return singles;
        }

        public async Task<int> UpdateSingle(Single single)
        {
            _context.Single.Update(single);
            return await _context.SaveChangesAsync();
        }
    }
}
