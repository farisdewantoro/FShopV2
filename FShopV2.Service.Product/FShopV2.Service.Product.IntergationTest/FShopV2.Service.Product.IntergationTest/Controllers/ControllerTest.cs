using FShopV2.Service.Product.IntergationTest.Fixture;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
namespace FShopV2.Service.Product.IntergationTest.Controllers
{
    public class ControllerTest:IClassFixture<MongoDbFixture>,IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly MongoDbFixture _mongoDbFixture;
        private readonly HttpClient _client;
        public ControllerTest(MongoDbFixture mongoDbFixture, WebApplicationFactory<Startup> factory)
        {
            _mongoDbFixture = mongoDbFixture;
            _client = factory.CreateClient(); //LEWAT RAM
        }
        [Theory]
        [InlineData("api/category")]
        public async Task Given_Endpoints_Should_Return_Success_Http_Status_Code(string endpoint)
        {

            var response = await _client.GetAsync(endpoint);
            response.IsSuccessStatusCode.Should().BeTrue();
        }
    }
}
