using Microsoft.AspNetCore.Mvc;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Enumerable.Empty<string>();
        }
    }
}
