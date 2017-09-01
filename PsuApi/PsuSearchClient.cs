using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassLibrary1;
using HtmlAgilityPack;
using PsuApi.Models;

namespace PsuApi
{
    public class PsuSearchClient : IPsuSearchClient
    {
        private HttpClient HttpClient { get; set; }

        /// <summary>
        ///     Retrieve Short information about person
        /// </summary>
        /// <param name="searchForm"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PsuSearchResult>> PostRetrieveShort(SearchForm searchForm)
        {
            var resultCollection = new ObservableCollection<PsuSearchResult>();
            HttpClient = new HttpClient();

            HttpResponseMessage respone;
            using (var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("sn", searchForm.Sn),
                new KeyValuePair<string, string>("cn", searchForm.Cn),
                new KeyValuePair<string, string>("uid", searchForm.Uid),
                new KeyValuePair<string, string>("mail", searchForm.Mail)
            }))
            {
                respone = await HttpClient.PostAsync(Constants.BaseApiUrl, formContent);
            }
            var responseContent = await respone.Content.ReadAsStringAsync();

            //Capute our respone to a html document
            var doc = new HtmlDocument();
            doc.LoadHtml(responseContent);

            //Foreach row in the table Linq query on the html document, seperate our objects by the table tag
            foreach (var row in from form in doc.DocumentNode.SelectNodes("//table")
                select new {text = form.InnerHtml})
            {
                var psuSearchResultObject = new PsuSearchResult();

                //Trim the row of anything we dont need
                var replacement = Regex.Replace(row.text, @"\t|\n|\r|amp;", "");

                //load our trimmed down string into a doc loader
                var localDoc = new HtmlDocument();
                localDoc.LoadHtml(replacement);

                 
                //Foreach row in the linqRow query to seperate the rows into objects
                foreach (var rows in from docRow in localDoc.DocumentNode.SelectNodes("./tr")
                    select new {CellTexty = docRow.InnerText})
                {
                    //Split the string on the : [0] is the header [1] is the content
                    var splitString = rows.CellTexty.Split(':');

                    if (splitString != null)
                        switch (splitString[0])
                        {
                            case "Name":
                                psuSearchResultObject.Name = splitString[1];
                                break;
                            case "E-mail":
                                psuSearchResultObject.Email = splitString[1];
                                break;
                            case "Mail ID":
                                psuSearchResultObject.MailId = splitString[1];
                                break;
                            case "Title":
                                psuSearchResultObject.Title = splitString[1];
                                break;
                            case "Administrative Area":
                                psuSearchResultObject.AdminArea = splitString[1];
                                break;
                            case "Campus":
                                psuSearchResultObject.Campus = splitString[1];
                                break;
                            case "Curriculum":
                                psuSearchResultObject.Curriculum = splitString[1];
                                break;
                            case "URL":
                                psuSearchResultObject.Url = splitString[1] + splitString[2];
                                break;
                            case "Telephone Number":
                                psuSearchResultObject.TelephoneNumber = splitString[1];
                                break;
                            case "Countries":
                                psuSearchResultObject.Countries = splitString[1];
                                break;
                            case "Languages":
                                psuSearchResultObject.Languages = splitString[1];
                                break;
                        }
                }

                resultCollection.Add(psuSearchResultObject);
                


            }

            return resultCollection;
        }
    }
}