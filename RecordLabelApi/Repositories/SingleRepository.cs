namespace RecordLabelApi.Repositories;
{
    public class SingleRepository : ISingleRepository
    {
        public Task<int> AddSingle(Models.Single single)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteSingle(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.Single> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.Single> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateSingle(Models.Single single)
        {
            throw new NotImplementedException();
        }
    }
}
