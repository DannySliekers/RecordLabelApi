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
            _context.Singles.Add(single);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSingle(int id)
        {
            var single = _context.Singles.FirstOrDefault(s => s.Id == id);
            _context.Singles.Remove(single);
            return await _context.SaveChangesAsync();
        }

        public Single Get(int id)
        {
            return _context.Singles.Find(id);
        }

        public IEnumerable<Single> GetAll()
        {
            return _context.Singles.ToList();
        }

        public async Task<int> UpdateSingle(Single single)
        {
            _context.Singles.Update(single);
            return await _context.SaveChangesAsync();
        }
    }
}
