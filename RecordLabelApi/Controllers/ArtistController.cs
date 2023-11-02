using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Models;
using RecordLabelApi.Repositories;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly IArtistRepository _repository;

        public ArtistController(ILogger<ArtistController> logger, IArtistRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Artist))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddArtist(Artist artist)
        {
            try
            {
                await _repository.AddArtist(artist);
                return Ok(artist);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while inserting artist");
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Artist> GetArtists()
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
