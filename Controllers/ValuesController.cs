using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sample_dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private static long idCounter = 0;
        private static Dictionary<long, string> values = new Dictionary<long, string>();

        // GET api/values
        [HttpGet]
        public ActionResult<Dictionary<long, string>> Get()
        {
            return values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            string value = "";
            if(!values.TryGetValue(id, out value))
            {
                return NotFound("ID not found");
            }
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            values.Add(Interlocked.Increment(ref idCounter), value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(long id, [FromBody] string value)
        {
            string existing = "";
            if(!values.TryGetValue(id, out existing))
            {
                return NotFound("ID not found");
            }
            values[id] = value;
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            values.Remove(id);
        }
    }
}
