using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using AngularNetCore2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace PsuApi.Tests
{
    [TestClass]
    [TestCategory("PennStateController")]
    public class PennStateControllerTest
    {

        [TestMethod]
        public void PennStateTest()
        {
            PennStateController localPennStateController = new PennStateController();

            var json = JObject.Parse("{ 'Cn': '', 'Sn': 'mammay', 'Uid': '', 'Mail':''} ");

            string content = SampleDataHelper.GetContent("ShortReturn.json");

            var responseMessage = new Func<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.OK){Content = new StringContent(content)});

            var verification = new Action<HttpRequestMessage, CancellationToken>((message, token) =>
            {
                Assert.AreEqual(HttpMethod.Post, message.Method);

            });

            var response = localPennStateController.Post(json);

            var firstResponse = response.Result.First();





            Assert.IsNotNull(firstResponse);
            



            

        }


    }
}
