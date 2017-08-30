using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Moq.Protected;

namespace PsuApi.Tests
{
    public static class Helper
    {

        public static PsuSearchClient CreateClient(Func<HttpResponseMessage>,
            Action<HttpRequestMessage, CancellationToken> verificationCallback)
        {

            var handler = new Mock<HttpMessageHandler>();
            handler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync")



            return null;
        }










    }
}
