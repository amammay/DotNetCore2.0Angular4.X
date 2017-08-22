using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace PlayGround.Controllers
{
    [Route("api/PennState")]
    public class PennStateController : Controller
    {
        /// <summary>
        /// Returns a json array 
        /// /api/PennState/GetArray
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable GetArray()
        {


            return new [] {"We are", "Penn State"};
        }


        /// <summary>
        /// Returns some json n'at
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetSomeJson")]
        public HttpResponseMessage GetSomeJson()
        {

            //example returns a HttpResponseMessage - the shim makes this possible
            var resp = new HttpResponseMessage()
            {
                Content = new StringContent("[{\"Name\":\"ABC\"},[{\"A\":\"1\"},{\"B\":\"2\"},{\"C\":\"3\"}]]")
            };
            
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
		    return resp;

        }
    }
}