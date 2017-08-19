using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PsuSearch.Models;

namespace PsuSearch
{
    public class PsuSearchClient : IPsuSearchClient
    {

        public HttpClient HttpClient { get; private set; }

        public async Task<PsuShortResult> PostRetrieveStudentShort(SearchForm searchForm)
        {
            string apiCall = "http://www.work.psu.edu/cgi-bin/ldap/ldap_query.cgi";

            HttpContent stringContent = new StringContent(searchForm.ToString());


            HttpResponseMessage respone = await HttpClient.GetAsync(apiCall);

            return new PsuShortResult();

        }
    }
}
