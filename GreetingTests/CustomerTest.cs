using System;
using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingTests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void SetCustomer_ShouldReturnString()
        {
            //Arrange
            Customer listContent = new Customer();

            //Act
            listContent.FirstName = "Abigail";

            //Assert
            Assert.AreEqual(listContent.FirstName, "Abigail");
        }
    }
}
