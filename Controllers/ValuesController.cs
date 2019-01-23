using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sample_dotnet_app.Services;

namespace sample_dotnet_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IValuesService valuesService;

        public ValuesController(IValuesService valuesService) {
            this.valuesService = valuesService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<object> Get()
        {
            return valuesService.RetrieveAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            object value = null;
            var success = valuesService.Retrieve(id, out value);
            if(success) {
                return Ok(value);
            }
            return NotFound("ID '" + id + "' Not Found");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            valuesService.Store(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(long id, [FromBody] string value)
        {
            var success = valuesService.Update(id, value);
            if(success) {
                return Ok();
            }
            return NotFound("ID '" + id + "' Not Found");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            valuesService.Delete(id);
        }
    }
}
