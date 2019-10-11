using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlexiPay.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        [NonAction]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [NonAction]
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [NonAction]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [NonAction]
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [NonAction]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
