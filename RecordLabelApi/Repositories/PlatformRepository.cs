using RecordLabelApi.Context;
using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly RecordLabelContext _context;

        public PlatformRepository(RecordLabelContext context)
        {
            _context = context;
        }

        public async Task<int> AddPlatform(Platform platform)
        {
            _context.Platform.Add(platform);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePlatform(int id)
        {
            var platform = _context.Platform.FirstOrDefault(p => p.id == id);
            _context.Platform.Remove(platform);
            return await _context.SaveChangesAsync();
        }

        public Platform Get(int id)
        {
            return _context.Platform.Find(id);
        }

        public IEnumerable<Platform> GetAll()
        {
            return _context.Platform.ToList();
        }

        public async Task<int> UpdatePlatform(Platform platform)
        {
            _context.Platform.Update(platform);
            return await _context.SaveChangesAsync();
        }
    }
}
