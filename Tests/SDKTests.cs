using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using SDK;
using SDK.Contracts;
using SDK.Enums;
using SDK.Models;
using SDK.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    public class SDKTests
    {                
        [TestCase]
        public async Task GetBooks()
        {
            // Arrange  
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();

            var mockedResponse = fixture.Build<BaseResponse<List<Book>>>()
                .With(x => x.Total, 10)
                .With(x => x.Offset, 0)
                .With(x => x.Page, 1)
                .With(x => x.Pages, 1)
                .Create();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(mockedResponse)),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);            
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            //Act
            var OneApi = new OneApi(httpClientFactory.Object);
            var results = await OneApi.RetrieveAll<Book>();

            //Assert            
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
        }

        [TestCase]
        public void BuildWithName()
        {
            var filter = FilterBuilder.BuildQueryString(new List<QueryParameter> { new QueryParameter { Field = "name", Filter = FilterEnum.Equals, Value = "Gandalf" } });
            Assert.That(filter, Is.EqualTo("limit=10&name=Gandalf"));
        }

        [TestCase]
        public void BuildIncludesName()
        {
            var filter = FilterBuilder.BuildQueryString(new List<QueryParameter> { 
                new QueryParameter { Field = "name", Filter = FilterEnum.Include, Value = "Gandalf" },
                new QueryParameter { Field = "name", Filter = FilterEnum.Include, Value = "Frodo" }
            });
            Assert.That(filter, Is.EqualTo("limit=10&name=Gandalf,Frodo"));
        }
    }
}
