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
    public class CustomersServiceTest
    {
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
