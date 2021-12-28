using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LongestSubsequence.Controllers
{
    public class SubsequenceController : ApiController
    {
        // GET: api/Subsequence
        [HttpGet]
        [Route("api/subsequence")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subsequence/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
