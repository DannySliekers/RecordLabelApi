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
            _context.Platforms.Add(platform);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeletePlatform(int id)
        {
            var platform = _context.Platforms.FirstOrDefault(p => p.Id == id);
            _context.Platforms.Remove(platform);
            return await _context.SaveChangesAsync();
        }

        public Platform Get(int id)
        {
            return _context.Platforms.Find(id);
        }

        public IEnumerable<Platform> GetAll()
        {
            return _context.Platforms.ToList();
        }

        public async Task<int> UpdatePlatform(Platform platform)
        {
            _context.Platforms.Update(platform);
            return await _context.SaveChangesAsync();
        }
    }
}
