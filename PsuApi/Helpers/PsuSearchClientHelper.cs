using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using PsuApi.Models;

namespace PsuApi.Helpers
{
    internal static class PsuSearchClientHelper
    {

        internal static ObservableCollection<PsuSearchResult> ParsePsuSearchResult(HtmlDocument htmlDocument, PsuSearchEnum searchEnum)
        {


            var resultCollection = new ObservableCollection<PsuSearchResult>();

            //Foreach row in the table Linq query on the html document, seperate our objects by the table tag
            foreach (var row in from form in htmlDocument.DocumentNode.SelectNodes("//table")
                                select new { text = form.InnerHtml })
            {
                var psuSearchResultObject = new PsuSearchResult {Search = searchEnum};

                //Trim the row of anything we dont need
                var replacement = Regex.Replace(row.text, @"\t|\n|\r|amp;", "");

                //load our trimmed down string into a doc loader
                var localDoc = new HtmlDocument();
                localDoc.LoadHtml(replacement);


                //Foreach row in the linqRow query to seperate the rows into objects
                foreach (var rows in from docRow in localDoc.DocumentNode.SelectNodes("./tr")
                                     select new { CellText = docRow.InnerText })
                {
                    //Split the string on the : [0] is the header [1] is the content
                    var splitString = rows.CellText.Split(':');

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
                                psuSearchResultObject.Url = splitString[1] + ":" + splitString[2];
                                break;
                            case "Telephone Number":
                                psuSearchResultObject.TelephoneNumber = splitString[1];
                                break;
                            case "Common Name":
                                psuSearchResultObject.CommonName = splitString[1];
                                break;
                            case "Last Name":
                                psuSearchResultObject.LastName = splitString[1];
                                break;
                            case "Given Name":
                                psuSearchResultObject.GivenName = splitString[1];
                                break;
                            case "Mailbox":
                                psuSearchResultObject.Mailbox = splitString[1];
                                break;
                            case "EduPerson Principal Name":
                                psuSearchResultObject.EduPersonPrincipalName = splitString[1];
                                break;
                            case "EduPerson Primary Affiliation":
                                psuSearchResultObject.EduPersonPrimaryAffiliation = splitString[1];
                                break;

                        }
                }

                resultCollection.Add(psuSearchResultObject);
            }

            return resultCollection;
        }


    }
}
