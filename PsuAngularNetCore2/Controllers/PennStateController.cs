using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PsuApi;
using PsuApi.Models;

namespace AngularNetCore2.Controllers
{
    [Route("api/[controller]")]
    public class PennStateController : Controller
    {
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
            var searchObject = json.ToObject<SearchForm>();

            var returnObjects = await psuClient.PostRetrieveSearch(searchObject);

            List<string> returnStringObj = new List<string>();


            //Checks to see if object properties are null, if they put them in the list
            //TODO comapare evertyhing in the list and see if everything is null
            foreach (var psuSearchResult in returnObjects)
            {
                foreach (var property in psuSearchResult.GetType().GetProperties()) {
                    if (property.PropertyType == typeof(string))
                    {
                        string value = (string) property.GetValue(psuSearchResult);
                        
                       
                        if (!string.IsNullOrEmpty(value))
                        {
                            returnStringObj.Add(property.Name);
                        }
                    }
                }
            }


            return await psuClient.PostRetrieveSearch(searchObject);
        }


        [HttpGet]
        public IEnumerable<string> Columns()
        {
            return new PsuSearchResult().ToEnumerableString();
        }
    }
}