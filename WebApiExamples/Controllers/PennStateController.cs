using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestClassLibrary;
using TestClassLibrary.Models;

namespace WebApiExamples.Controllers
{
    [Route("api/[controller]")]
    public class PennStateController : Controller
    {

        // GET api/values
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



        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }





    }
}