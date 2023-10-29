using Microsoft.AspNetCore.Mvc;

namespace RecordLabelApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingleController
    {
        [HttpGet(Name = "GetSingles")]
        public IEnumerable<string> Get()
        {
            return Enumerable.Empty<string>();
        }
    } 
}
