using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Models;
using RecordLabelApi.Repositories;

namespace RecordLabelApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IAlbumRepository _repository;

        public AlbumController(ILogger<AlbumController> logger, IAlbumRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            try
            {
                await _repository.DeleteAlbum(id);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while deleting album");
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddAlbum(Album album)
        {
            try
            {
                await _repository.AddAlbum(album);
                return Ok(album);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while inserting album");
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Album))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateAlbum(Album album)
        {
            try
            {
                await _repository.UpdateAlbum(album);
                return Ok(album);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while updating album");
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Album> GetAlbums()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Album GetById(int id)
        {
            return _repository.Get(id);
        }
    }
}
