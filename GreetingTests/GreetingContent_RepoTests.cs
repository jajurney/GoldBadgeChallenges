using System;
using System.Collections.Generic;
using Greeting_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreetingTests
{
    [TestClass]
    public class GreetingContent_RepoTests
    {
        [TestMethod]
        public void AddCustomer_ShouldReturnTrue()
        {
            //Arrange
            Customer listContent = new Customer();
            GreetingContent_Repo repository = new GreetingContent_Repo();
            //Act
            bool custAdded = repository.AddCustomerToList(listContent);
            //Assert
            Assert.IsTrue(custAdded);
        }
        [TestMethod]
        public void GetCustomers_ShouldReturnList()
        {
            //Arrange
            Customer listContent = new Customer();
            GreetingContent_Repo repo = new GreetingContent_Repo();
            //Act
            repo.AddCustomerToList(listContent);
            List<Customer> listContents = repo.GetCustomers();
            bool custList = listContents.Contains(listContent);
            //Assert
            Assert.IsTrue(custList);
        }
        [TestMethod]
        public void UpdateExistngCustomer_ShouldGetTrue()
        {
            //Arrange
            GreetingContent_Repo repo = new GreetingContent_Repo();
            Customer oldCust = new Customer("Abigail", "Light", "Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            repo.AddCustomerToList(oldCust);
            Customer newCust = new Customer("Abigail", "Light", "Past", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            //Act
            bool updateCust = repo.UpdateCustomerInfo("Light", newCust);
            //Assert
            Assert.IsTrue(updateCust);
        }
        [TestMethod]
        public void DeleteCustomer_ShouldGetTrue()
        {
            //Arrange
            GreetingContent_Repo repo = new GreetingContent_Repo();
            Customer listContent = new Customer("Abigail", "Light", "Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            repo.AddCustomerToList(listContent);
            //Act
            Customer oldCust = repo.GetCustomerByLastName("Light");
            bool deleteCust = repo.DeleteExistingCustomer(oldCust);
            //Assert
            Assert.IsTrue(deleteCust);
        }
    }
}
