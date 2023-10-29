using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Models;
using RecordLabelApi.Repositories;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController
    {
        private readonly IArtistRepository _repository;
        public ArtistController(IArtistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Artist>> Get()
        {
            return await _repository.GetAll();
        }
    }
}
