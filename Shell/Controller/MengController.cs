using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shell.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MengController : ControllerBase
    {
        // GET: api/<MengController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MengController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "succccess fck" + id.ToString();
        }

        // POST api/<MengController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MengController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MengController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
