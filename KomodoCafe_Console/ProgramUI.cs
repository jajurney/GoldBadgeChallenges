using KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    public class ProgramUI
    {
        private KomodoCafe_Repo _repo = new KomodoCafe_Repo();
        public void Run()
        {
            MenuItems();
            Menu();


        }

        public void MenuItems()
        {
            MenuContent burgerCombo = new MenuContent(1, "Burger Combo", "Burger with all the fixin's, you'll love it.", 5.50, "Bun, Hamburger, Lettuce, Onion, Ketchup, Mustard");
            MenuContent chickenCombo = new MenuContent(2, "Chicken Combo", "Fried Chicken Tenders with dipping suaces.", 8.50, "Chicken, Wheat(breading)");
            MenuContent fishCombo = new MenuContent(3, "Fish Combo", "Fried fish fillets with fries and tartar sausce.", 10.50, "Fish, potatoes, Wheat(breading)");
            MenuContent turkeyCombo = new MenuContent(4, "Turkey Combo", "Turkey sandwich with lots of extras.", 8.50, "Turkey, lettuce, bacon, tomato, bread slices");
            MenuContent beefCombo = new MenuContent(5, "Beef Combo", "Meatloaf with mashed potatoes.", 13.50, "Ground Beef, bread crumbs, ketchup, garlic");
            _repo.AddItemToMenu(burgerCombo);
            _repo.AddItemToMenu(chickenCombo);
            _repo.AddItemToMenu(fishCombo);
            _repo.AddItemToMenu(turkeyCombo);
            _repo.AddItemToMenu(beefCombo);
        }
        private void Menu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Chose a number to continue:\n" +
                    "1. Show Full Menu\n" +
                    "2. Add Menu Items\n" +
                    "3. Update Menu Items\n" +
                    "4. Delete Menu Items\n" +
                    "5. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        CreateNewMenuItem();
                        break;
                    case "3":
                        UpdateMenuItems();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;
                    case "5":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Select a Number.");
                        Console.ReadLine();
                        break;

                }
            }
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            List<MenuContent> listOfMenuContents = _repo.GetMenu();

            foreach (MenuContent menuContent in listOfMenuContents)
            {
                DisplayMenu(menuContent);

            }
            Console.WriteLine("Press any key to move on.");
            Console.ReadKey();
        }
        private void CreateNewMenuItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            MenuContent newMenuContent = new MenuContent();

            Console.WriteLine("Enter New Menu Item Number:");
            string mealNumInput = Console.ReadLine();
            int mealNumAsInt = int.Parse(mealNumInput);
            newMenuContent.MealNum = mealNumAsInt;

            Console.WriteLine("Enter New Item Name:");
            newMenuContent.MealItem = Console.ReadLine();

            Console.WriteLine("Enter New Item Description:");
            newMenuContent.MealDescription = Console.ReadLine();

            Console.WriteLine("Enter New Item Price:");
            string priceAsString = Console.ReadLine();
            double priceAsDouble = double.Parse(priceAsString);
            newMenuContent.MealPrice = priceAsDouble;

            Console.WriteLine("Enter New Item Ingredients:");
            newMenuContent.Ingredients = Console.ReadLine();


            bool itemAdded = _repo.AddItemToMenu(newMenuContent);
            if (itemAdded)
            {
                Console.WriteLine("You have added the new item");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Oh no, something got messed up, let's try again.");
                Console.ReadLine();
            }
        }
        private void UpdateMenuItems()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter item you would like to update");
            string mealItem = Console.ReadLine();

            MenuContent oldItem = _repo.GetItemByMealName(mealItem);
            if (oldItem == null)
            {
                Console.WriteLine("Menu item is not available.");
                Console.ReadKey();
                return;
            }

            MenuContent newItem = new MenuContent(
                oldItem.MealNum,
                oldItem.MealItem,
                oldItem.MealDescription,
                oldItem.MealPrice,
                oldItem.Ingredients
                );
            Console.WriteLine("Choose what you would like to update:\n" +
                "1. Meal Number\n" +
                "2. Meal Item\n" +
                "3. Meal Description\n" +
                "4. Meal Price\n" +
                "5. Ingredients");
            char option = Console.ReadKey().KeyChar;
            switch (option)
            {
                case '1':
                    Console.WriteLine("Enter Updated Meal Number");
                    int newNum = int.Parse(Console.ReadLine());
                    newItem.MealNum = newNum;

                    bool numUpdated = _repo.UpdateMenuItems(mealItem, oldItem);
                    if (numUpdated)
                    {
                        Console.WriteLine("Item Number has been updated.");
                    }
                    else
                    {
                        Console.WriteLine($"Item number bad, could not update {mealItem}");
                    }
                    break;
                case '2':
                    Console.WriteLine("Enter Updated Item Name");
                    string item = Console.ReadLine();
                    newItem.MealItem = item;

                    bool nameUpdated = _repo.UpdateMenuItems(mealItem, oldItem);
                    if (nameUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Could not update {mealItem}");
                    }
                    break;
                case '3':
                    Console.WriteLine("Enter Updated Meal Description");
                    string itemDescription = Console.ReadLine();
                    newItem.MealDescription = itemDescription;

                    bool descUpdated = _repo.UpdateMenuItems(mealItem, oldItem);
                    if (descUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Could not update {mealItem}.");
                    }
                    break;
                case '4':
                    Console.WriteLine("Enter Updated Item Price");
                    string priceAsString = Console.ReadLine();
                    double priceAsDouble = double.Parse(priceAsString);
                    newItem.MealPrice = priceAsDouble;

                    bool priceUpdated = _repo.UpdateMenuItems(mealItem, oldItem);
                    if (priceUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {mealItem}.");
                    }
                    break;
                case '5':
                    Console.WriteLine("Enter Updated Ingredients:");
                    newItem.Ingredients = Console.ReadLine();

                    bool ingredUpdated = _repo.UpdateMenuItems(mealItem, oldItem);
                    if (ingredUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {mealItem}.");
                    }
                    break;
                default:
                    Console.WriteLine("Menu Has Been updated.");
                    return;
                    


            }
        }
        private void DeleteMenuItem()
        {
            ShowAllMenuItems();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Meal Item to delete:");
            string itemDelete = Console.ReadLine();

            MenuContent mealToDelete = _repo.GetItemByMealName(itemDelete);
            bool deleteMenuItem = _repo.DeleteMenuItem(mealToDelete);
            if (deleteMenuItem)
            {
                Console.WriteLine("The Meal Item has been deleted");
            }
            else
            {
                Console.WriteLine("Error: Could not delete Meal Item");
            }
        }
        private void DisplayMenu(MenuContent menuContent)
        {
            Console.WriteLine($"Meal Number: {menuContent.MealNum,-15}");
            Console.WriteLine($"Meal Item: {menuContent.MealItem,-15}");
            Console.WriteLine($"Description: {menuContent.MealDescription,-15}");
            Console.WriteLine($"Price: {menuContent.MealPrice,-15}");
            Console.WriteLine($"Ingredients: {menuContent.Ingredients,-15}");
        }
    }
}
