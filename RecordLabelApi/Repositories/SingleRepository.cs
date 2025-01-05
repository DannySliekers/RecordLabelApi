using RecordLabelApi.Context;
using RecordLabelApi.Models;
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

        public async Task<int> AddSingle(SingleRequest singleRequest)
        {
            var single = new Single()
            {
                title = singleRequest.Title,
                cover = singleRequest.Cover,
                playlength = singleRequest.Playlength,
                status = singleRequest.Status,
                artistid = singleRequest.ArtistId
            };

            var addedSingle = _context.Single.Add(single);

            await _context.SaveChangesAsync();

            foreach (var platformId in singleRequest.PlatformIds)
            {
                var singlePlatform = new SinglePlatform()
                {
                    singleid = addedSingle.Entity.id,
                    platformid = platformId
                };

                _context.SinglePlatform.Add(singlePlatform);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteSingle(int id)
        {
            var single = _context.Single.FirstOrDefault(s => s.id == id);
            _context.Single.Remove(single);
            return await _context.SaveChangesAsync();
        }

        public SingleRequest Get(int id)
        {
            var single = _context.Single.Find(id);
            var platformIds = _context.SinglePlatform
                               .Where(x => x.singleid == single.id)
                               .Select(x => x.platformid)
                               .ToList();

            var singleRequest = new SingleRequest()
            {
                Id = single.id,
                Title = single.title,
                Cover = single.cover,
                Status = single.status,
                Playlength = single.playlength,
                ArtistId = single.artistid,
                PlatformIds = platformIds
            };
            return singleRequest;
        }

        public IEnumerable<SingleRequest> GetAll()
        {
            var singleRequestList = new List<SingleRequest>();

            foreach (var single in _context.Single.ToList())
            {
                var platformIds = _context.SinglePlatform
                                   .Where(x => x.singleid == single.id)
                                   .Select(x => x.platformid)
                                   .ToList();

                var singleRequest = new SingleRequest()
                {
                    Id = single.id,
                    Title = single.title,
                    Cover = single.cover,
                    Status = single.status,
                    Playlength = single.playlength,
                    ArtistId = single.artistid,
                    PlatformIds = platformIds
                };

                singleRequestList.Add(singleRequest);
            }

            return singleRequestList;
        }

        public IEnumerable<SingleRequest> GetByArtistId(int artistId)
        {
            var artist = _context.Artist.Find(artistId);
            var singles = _context.Single.Where(single => single.artistid == artistId).ToList();

            var singleRequestList = new List<SingleRequest>();

            foreach (var single in singles)
            {
                var platformIds = _context.SinglePlatform
                                   .Where(x => x.singleid == single.id)
                                   .Select(x => x.platformid)
                                   .ToList();

                var singleRequest = new SingleRequest()
                {
                    Id = single.id,
                    Title = single.title,
                    Cover = single.cover,
                    Status = single.status,
                    Playlength = single.playlength,
                    ArtistId = single.artistid,
                    PlatformIds = platformIds
                };

                singleRequestList.Add(singleRequest);
            }

            return singleRequestList;
        }

        public async Task<int> UpdateSingle(SingleRequest singleRequest)
        {
            var single = new Single()
            {
                id = (int) singleRequest.Id,
                title = singleRequest.Title,
                cover = singleRequest.Cover,
                playlength = singleRequest.Playlength,
                status = singleRequest.Status,
                artistid = singleRequest.ArtistId
            };

            var platformIds = _context.SinglePlatform
                   .Where(x => x.singleid == single.id)
                   .ToList();

            _context.SinglePlatform.RemoveRange(platformIds);
            await _context.SaveChangesAsync();

            foreach (var platformId in singleRequest.PlatformIds)
            {
                var singlePlatform = new SinglePlatform()
                {
                    singleid = (int) singleRequest.Id,
                    platformid = platformId
                };

                _context.SinglePlatform.Add(singlePlatform);
            }

            _context.Single.Update(single);
            return await _context.SaveChangesAsync();
        }
    }
}
