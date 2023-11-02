using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Repositories
{
    public interface ISingleRepository
    {
        IEnumerable<Single> GetAll();
        Single Get(int id);
        Task<int> AddSingle(Single single);
        Task<int> UpdateSingle(Single single);
        Task<int> DeleteSingle(int id);
    }
}
