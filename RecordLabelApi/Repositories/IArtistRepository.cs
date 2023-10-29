using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAll();
    }
}
