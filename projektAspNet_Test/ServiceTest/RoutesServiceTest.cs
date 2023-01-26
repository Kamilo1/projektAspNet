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
    public class RoutesServiceTest
    {
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
