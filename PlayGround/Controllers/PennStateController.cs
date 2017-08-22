using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace PlayGround.Controllers
{
    [Route("api/[controller]")]
    public class PennStateController : Controller
    {


        [HttpGet("[action]")]
        public IEnumerable GetArray()
        {
            //example returns a basic type that is automatically serialized as json
            return new string[] { "value2", "value3" };
        }

        [HttpGet("[action]")]
        public object GetSomeObject()
        {
            //example returns an object that is automatically serialized as json
            return new { color = "red", today = DateTime.UtcNow };
        }

        [HttpGet]
        public IActionResult CreateSomething()
        {
            return StatusCode(201); //set status code
        }

        [HttpGet("[action]")]
        public string Greet(string id)
        {
            return $"Hello {id}";
        }
    }
}