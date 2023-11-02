using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Models;
using RecordLabelApi.Repositories;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly ILogger<PlatformController> _logger;
        private readonly IPlatformRepository _repository;

        public PlatformController(ILogger<PlatformController> logger, IPlatformRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(Platform))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            try
            {
                await _repository.DeletePlatform(id);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while deleting platform");
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Platform))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPlatform(Platform platform)
        {
            try
            {
                await _repository.AddPlatform(platform);
                return Ok(platform);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while inserting platform");
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Platform))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdatePlatform(Platform platform)
        {
            try
            {
                await _repository.UpdatePlatform(platform);
                return Ok(platform);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while updating platform");
                return BadRequest();
            }
        }

        [HttpGet]
        public List<Platform> GetPlatforms()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Platform GetById(int id)
        {
            return _repository.Get(id);
        }
    }
}
