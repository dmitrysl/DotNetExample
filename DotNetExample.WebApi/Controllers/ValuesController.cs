using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DotNetExample.WebApi.Controllers
{
    //[Authorize]
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<object>> Get()
        {
            return await Task.Run(() => new object[] { new { Id = 1, Title = "title 1" }, new { Id = 1, Title = "test 2" } });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
