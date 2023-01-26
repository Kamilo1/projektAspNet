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
    public class CustomersControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _httpClient;

        public CustomersControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _httpClient = _factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Customers/Index")]
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
        [InlineData("Franek", "Kowalski")]
        public async Task CustomersController_CustomerByFirstName_ReturnsFranekKowalski(string FirstName, string LastName)
        {
            //Arrange

            //Act
            var resposne = await _httpClient.GetAsync("/Customers/Index");
            var pageContent = await resposne.Content.ReadAsStringAsync();
            var contentString = pageContent.ToString();
            //Assert
            Assert.Contains(FirstName, contentString);
        }


        [Fact]
        public void CreateCustomer()
        {
            // Arrange
            var customer = new Customer { FirstName = "Franek", LastName = "Kowalski", Pesel = "11611111611", Telephone = "010601060", CompanyName = "Apple", NIP = "4444444444" };
            var service = new CustomersServiceEF(null);

            // Act
            var result = service.CreateCustomer(customer);

            // Assert
            Assert.IsType<Customer>(result);
            Assert.Equal("Franek", result.FirstName);
            Assert.Equal("Kowalski", result.LastName);
            Assert.Equal("11611111611", result.Pesel);
            Assert.Equal("010601060", result.Telephone);
            Assert.Equal("Apple", result.CompanyName);
            Assert.Equal("4444444444", result.NIP);

        }
    }
}
