using RecordLabelApi.Models;

namespace RecordLabelApi.Repositories
{
    public interface IArtistRepository
    {
        IQueryable<Artist> GetAll();
        IQueryable<Artist> Get(int id);
    }
}
