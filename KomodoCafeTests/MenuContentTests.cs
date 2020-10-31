using System;
using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuContentTests
    {
        [TestMethod]
        public void SetItem_ShouldReturnString()
        {
            //Arrage
            MenuContent menuContent = new MenuContent();

            //Act
            menuContent.MealItem = "Burger Combo";
            //Assert
            Assert.AreEqual(menuContent.MealItem, "Burger Combo");
        }
    }
}
