using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KomodoCafeTests
{
    [TestClass]
    public class KomodoCafe_RepoTests
    {
        [TestMethod]
        public void AddToMenu_ShouldGetBool()
        {
            //Arrange
            MenuContent menuContent = new MenuContent();
            KomodoCafe_Repo repository = new KomodoCafe_Repo();
            //Act
            bool itemAdded = repository.AddItemToMenu(menuContent);
            //Assert
            Assert.IsTrue(itemAdded);
        }
        [TestMethod]
        public void GetMenu_ShouldReturnCorrectList()
        {
            //Arrange
            MenuContent menuContent = new MenuContent();
            KomodoCafe_Repo repo = new KomodoCafe_Repo();

            //Act
            repo.AddItemToMenu(menuContent);
            List<MenuContent> menuContents = repo.GetMenu();
            bool menuHasItems = menuContents.Contains(menuContent);

            //Assert
            Assert.IsTrue(menuHasItems);

        }
        [TestMethod]
        public void UpdateExistingMenu_ShouldGetTrue()
        {
            //Arrange
            KomodoCafe_Repo repo = new KomodoCafe_Repo();
            MenuContent oldItem = new MenuContent(1, "Burger Combo", "Burger with all the fixin's, you'll love it.", 5.50, "Bun, Hamburger, Lettuce, Onion, Ketchup, Mustard");
            repo.AddItemToMenu(oldItem);

            MenuContent newItem = new MenuContent(1, "Burger Combo", "Burger with all the fixin's, you'll love it.", 9.50, "Bun, Hamburger, Lettuce, Onion, Ketchup, Mustard");
            //Act
            bool updateItem = repo.UpdateMenuItems("Burger Combo", newItem);

            //Assert
            Assert.IsTrue(updateItem);

        }
        [TestMethod]
        public void DeleteMenuItem_ShoudGetTrue()
        {
            //Arrange
            KomodoCafe_Repo repo = new KomodoCafe_Repo();
            MenuContent menuContent = new MenuContent(1, "Burger Combo", "Burger with all the fixin's, you'll love it.", 5.50, "Bun, Hamburger, Lettuce, Onion, Ketchup, Mustard");
            repo.AddItemToMenu(menuContent);
            //Act
            MenuContent oldItem = repo.GetItemByMealName("Burger Combo");
            bool deleteItem = repo.DeleteMenuItem(oldItem);
            //Assert
            Assert.IsTrue(deleteItem);


        }
    }
}
