using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IPlatformRepository
    {
        IEnumerable<Platform> GetAll();
        Platform Get(int id);
        Task<int> AddPlatform(Platform platform);
        Task<int> UpdatePlatform(Platform platform);
        Task<int> DeletePlatform(int id);
    }
}
