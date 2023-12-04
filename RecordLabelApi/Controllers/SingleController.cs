using Microsoft.AspNetCore.Mvc;
using RecordLabelApi.Repositories;
using Single = RecordLabelApi.Models.Single;

namespace RecordLabelApi.Controllers
{
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
        [ProducesResponseType(200, Type = typeof(Single))]
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
        [ProducesResponseType(200, Type = typeof(Single))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddSingle(Single single)
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
        [ProducesResponseType(200, Type = typeof(Single))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateSingle(Single single)
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
        public List<Single> GetSingles()
        {
            return _repository.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Single GetById(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet("{artistId}")]
        public List<Single> GetSinglesByArtistId(int artistId)
        {
            return _repository.GetByArtistId(artistId).ToList();
        }
    }
}
