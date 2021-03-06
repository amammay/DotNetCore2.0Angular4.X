﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ClassLibrary1;
using HtmlAgilityPack;
using PsuApi.Helpers;
using PsuApi.Models;

namespace PsuApi
{
    public class PsuSearchClient : IPsuSearchClient
    {
        private HttpClient HttpClient { get; set; }

        /// <summary>
        /// Method for using Penn State LDAP 
        /// </summary>
        /// <param name="searchFrom"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PsuSearchResult>> PostRetrieveSearch(SearchForm searchFrom)
        {
            HttpClient = new HttpClient();

            var responseContent = RequestSender(searchFrom);

            //Capute our respone to a html document
            var doc = new HtmlDocument();
            doc.LoadHtml(await responseContent);

            return PsuSearchClientHelper.ParsePsuSearchResult(doc, searchFrom.Full);
        }
        
        /// <summary>
        /// Helper method for getting content from PennState ldap . 
        /// </summary>
        /// <param name="searchObject"></param>
        /// <returns> Returns string of content</returns>
        private async Task<string> RequestSender(SearchForm searchObject)
        {
            HttpClient = new HttpClient();
            int intEnum = (int)searchObject.Full;
            HttpResponseMessage respone;

            using (var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("sn", searchObject.Sn),
                new KeyValuePair<string, string>("cn", searchObject.Cn),
                new KeyValuePair<string, string>("uid", searchObject.Uid),
                new KeyValuePair<string, string>("mail", searchObject.Mail),
                new KeyValuePair<string,string>("full", intEnum.ToString())
            }))
            {
                respone = await HttpClient.PostAsync(Constants.BaseApiUrl, formContent);
            }
            return await respone.Content.ReadAsStringAsync();
        }

    }


}