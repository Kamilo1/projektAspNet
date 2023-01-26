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

namespace projektAspNet_Test.ServiceTest
{
    public class EventsServiceTest
    {
        [Fact]
        public void CreateEvents()
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
