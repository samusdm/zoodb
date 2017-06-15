using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZooApp.Controllers
{
    public class TiposAnimalController : ApiController
    {
        // GET: api/TiposAnimal
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TiposAnimal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TiposAnimal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TiposAnimal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TiposAnimal/5
        public void Delete(int id)
        {
        }
    }
}
