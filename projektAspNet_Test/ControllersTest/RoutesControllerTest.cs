using Microsoft.AspNetCore.Mvc.Testing;
using projektAspNet.Models;
using projektAspNet.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace projektAspNet_Test.ControllersTest
{
    public class RoutesControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public RoutesControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Routes/Index")]
        [InlineData("/Customers/Index")]
        [InlineData("/Home/Index")]
        public async Task Test_All_Pages(string url)
        {
            //Arrange
            var client = _factory.CreateClient();
            //Act
            var resposne = await client.GetAsync(url);
            int code = (int)resposne.StatusCode;
            //Assert
            Assert.Equal(200, code);
        }

        [Theory]
        [InlineData("wadowice-krakow", "Bardzo zaawansowana")]
        public async Task RoutesController_RoutesByRouteName_ReturnsWadowiceKrakow(string RouteName, string Difficulty)
        {
            //Arrange

            //Act
            var resposne = await _httpClient.GetAsync("/Routes/Index");
            var pageContent = await resposne.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();
            //Assert
            Assert.Contains(RouteName, contentString);
        }

        [Fact]
        public void CreateRoute()
        {
            // Arrange
            var routes = new Route { RouteName = "wadowice-krakow", Difficulty = "Bardzo zaawansowana", Route_Length = "20km" };
            var service = new RoutesServiceEF(null);

            // Act
            var result = service.CreateRoute(routes);

            // Assert
            Assert.IsType<Route>(result);
            Assert.Equal("wadowice-krakow", result.RouteName);
            Assert.Equal("Bardzo zaawansowana", result.Difficulty);
            Assert.Equal("20km", result.Route_Length);
        }


    }
}