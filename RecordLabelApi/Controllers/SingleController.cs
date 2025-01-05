using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Models;
using RecordLabelApi.Repositories;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SingleController : ControllerBase
    {
        private readonly ILogger<SingleController> _logger;
        private readonly ISingleRepository _repository;

        public SingleController(ILogger<SingleController> logger, ISingleRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpDelete]
        [ProducesResponseType(200, Type = typeof(SingleRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> DeleteSingle(int id)
        {
            try
            {
                await _repository.DeleteSingle(id);
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while deleting single");
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(SingleRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddSingle(SingleRequest single)
        {
            try
            {
                await _repository.AddSingle(single);
                return Ok(single);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while inserting single");
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(SingleRequest))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSingle(SingleRequest single)
        {
            try
            {
                await _repository.UpdateSingle(single);
                return Ok(single);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while updating single");
                return BadRequest();
            }
        }

        [HttpGet]
        public List<SingleRequest> GetSingles()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public SingleRequest GetById(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet("byArtist/{artistId}")]
        public List<SingleRequest> GetSinglesByArtistId(int artistId)
        {
            return _repository.GetByArtistId(artistId).ToList();
        }
    }
}
