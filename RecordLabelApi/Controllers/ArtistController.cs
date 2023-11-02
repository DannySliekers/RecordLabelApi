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

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(Artist))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            try
            {
                await _repository.DeleteArtist(id);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while deleting artist");
                return BadRequest();
            }
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

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Artist))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateArtist(Artist artist)
        {
            try
            {
                await _repository.UpdateArtist(artist);
                return Ok(artist);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while updating artist");
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Artist> GetArtists()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Artist GetById(int id)
        {
            return _repository.Get(id);
        }
    }
}
