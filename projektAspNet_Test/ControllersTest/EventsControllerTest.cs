using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projektAspNet.Service;
using projektAspNet.Data;
using projektAspNet.Controllers;
using projektAspNet.Models;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Diagnostics.Metrics;

namespace projektAspNet_Test.ControllersTest
{
    public class EventsControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public EventsControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Events/Index")]
        [InlineData("/Routes/Index")]
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
        [InlineData("Dwudniowy spływ Odrą", "Wrocław")]
        public async Task EventsController_GetEventByEventName_ReturnsDwudniowySplyw(string EventName, string Event_Location)
        {
            //Arrange

            //Act
            var resposne = await _httpClient.GetAsync("/Events/Index");
            var pageContent = await resposne.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();
            //Assert
            Assert.Contains(EventName, contentString);
        }


        [Fact]
        public void CreateEvents_ReturnsEvent_OnSuccess()
        {
            // Arrange
            var events = new Event { EventName = "Dwudniowy spływ Odrą", DateOfEvent = DateTime.Parse("2006-10-25"), Event_Location = "Wrocław" };
            var service = new EventsServiceEF(null);

            // Act
            var result = service.CreateEvent(events);

            // Assert
            Assert.IsType<Event>(result);
            Assert.Equal("Dwudniowy spływ Odrą", result.EventName);
            Assert.Equal(DateTime.Parse("2006-10-25"), result.DateOfEvent);
            Assert.Equal("Wrocław", result.Event_Location);
        }
    }
}
