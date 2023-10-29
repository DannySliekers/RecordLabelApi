using Microsoft.AspNetCore.Mvc;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Enumerable.Empty<string>();
        }
    }
}
