using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Repositories;
{
    public interface ISingleRepository
    {
        IQueryable<Single> GetAll();
        IQueryable<Single> Get(int id);
        Task<int> AddSingle(Single single);
        Task<int> UpdateSingle(Single single);
        Task<int> DeleteSingle(int id);
    }
}
