using RecordLabelApi.Models;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Repositories
{
    public interface ISingleRepository
    {
        IEnumerable<SingleRequest> GetAll();
        SingleRequest Get(int id);
        Task<int> AddSingle(SingleRequest single);
        Task<int> UpdateSingle(SingleRequest single);
        Task<int> DeleteSingle(int id);
        IEnumerable<SingleRequest> GetByArtistId(int artistId);
    }
}
