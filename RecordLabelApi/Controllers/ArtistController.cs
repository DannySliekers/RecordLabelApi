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
        public List<Artist> Get()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public List<Artist> GetById(int id)
        {
            return _repository.Get(id).ToList();
        }
    }
}
