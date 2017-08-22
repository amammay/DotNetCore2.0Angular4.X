using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TestClassLibrary;
using TestClassLibrary.Models;

namespace WebApiExamples.Controllers
{
    [Route("api/[controller]")]
    public class PennStateController : Controller
    {
        // GET api/PennState
        [HttpGet]
        public async Task<IEnumerable<PsuSearchResult>> PsuShort()
        {
            var psuClient = new PsuSearchClient();

            var form = new SearchForm
            {
                Sn = "ma"
            };

            var objectResults = await psuClient.PostRetrieveShort(form);


            return objectResults;
        }


        // POST api/PennState
        /// <summary>
        ///     Uses the form body to get applicable information
        /// </summary>
        /// <param name="json"></param>
        /// <returns> Json object of the search result</returns>
        [HttpPost]
        public async Task<IEnumerable<PsuSearchResult>> Post([FromBody] JObject json)
        {
            var psuClient = new PsuSearchClient();
            return await psuClient.PostRetrieveShort(json.ToObject<SearchForm>());
        }
    }
}