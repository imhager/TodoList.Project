using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoList.Framework;
using Microsoft.Extensions.Logging;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IJsonSerializable _jsonSerializable;
        private ILogger<ValuesController> _logger;

        public ValuesController(IJsonSerializable jsonSerializable, ILogger<ValuesController> logger)
        {
            _jsonSerializable = jsonSerializable;
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            var s = new string[] { "value1", "value2", "value3", "value4" };
            var result = _jsonSerializable.ToJson(s);
            _logger.LogInformation(result);

            return result;
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
