using Greeting_Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Greeting_Console
{
    class ProgramUI
    {
        private GreetingContent_Repo _repo = new GreetingContent_Repo();

        public void Run()
        {
            ExistingCustomerData();
            Menu();
        }
        private void ExistingCustomerData()
        {
            Customer baseContent = new Customer("First Name:", "Last Name:", "Type:", "Email Message:");
            Customer custOne = new Customer("Abigail", "Light", "Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.");
            Customer custTwo = new Customer("Blake", "Fisher", "Past", "It's been a long time since we've heard from you, we want you back");
            Customer custThree = new Customer("Carolynn", "Pudd", "Potenial", "We currently have the lowest rates on Helicopter Insurance!");
            Customer custFour = new Customer("Donovan", "Credit", "Current", "Take a look at our new rates, and see if you'd be interest in upgrading!");
            Customer custFive = new Customer("Freddy", "Kruger", "Potenial", "We currently have great liability insure options for you.");


            _repo.AddCustomerToList(baseContent);
            _repo.AddCustomerToList(custOne);
            _repo.AddCustomerToList(custTwo);
            _repo.AddCustomerToList(custThree);
            _repo.AddCustomerToList(custFour);
            _repo.AddCustomerToList(custFive);
        }
        

        private void Menu()
        {
            bool continueRun = true;
            while (continueRun)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter the nubmer of the option you would like:\n" +
                    "1. Show all Customers\n" +
                    "2. Find customer by last name\n" +
                    "3. Add new Customer\n" +
                    "4. Update existing Customer\n" +
                    "5. Remove Customer\n" +
                    "6. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        ShowAllCustomers();
                        break;
                    case "2":

                        GetCustomerByLastName();
                        break;
                    case "3":

                        CreateNewCustomers();
                        break;
                    case "4":

                        UpdateCustomerbyLastName();
                        break;
                    case "5":

                        DeleteCustomerByLastName();
                        break;
                    case "6":

                        continueRun = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void ShowAllCustomers()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            List<Customer> listOfCustomers = _repo.GetCustomers();

            foreach (Customer listContent in listOfCustomers)
            {
                DisplayCustomers(listContent);
            }
            Console.WriteLine("Press a key to continue");

            Console.ReadKey();
        }
        private void CreateNewCustomers()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Customer newCust = new Customer();

            Console.WriteLine("Enter new First Name");
            newCust.FirstName = Console.ReadLine();

            Console.WriteLine("Enter new Last Name");
            newCust.LastName = Console.ReadLine();

            Console.WriteLine("Enter new Customer Type: Potential, Current, or Past.");
            newCust.CustType = Console.ReadLine();

            Console.WriteLine("Enter Email Message per customer type.");
            newCust.Email = Console.ReadLine();

            bool custAdded = _repo.AddCustomerToList(newCust);
            if (custAdded)
            {
                Console.WriteLine("New Customer Added");
            }
            else
            {
                Console.WriteLine("Something went wrong try again.");
            }
        }
        private void GetCustomerByLastName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Enter Last Name of Customer you would like to see.");
            string lastName = Console.ReadLine();
            _repo.GetCustomerByLastName(lastName);
            Customer listContent = _repo.GetCustomerByLastName(lastName);
            if (listContent != null)
            {
                DisplayCustomers(listContent);
            }
            else
            {
                Console.WriteLine("Sorry that customer does not Exist.");
            }
            Console.ReadKey();
        }
        private void UpdateCustomerbyLastName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Enter customer last name to update.");
            string lastName = Console.ReadLine();
            Customer oldCust = _repo.GetCustomerByLastName(lastName);
            if (oldCust == null)
            {
                Console.WriteLine("Content not found, press any key to continue.");
                Console.ReadKey();
                return;

            }
            Customer newCust = new Customer(
                oldCust.FirstName,
                oldCust.LastName,
                oldCust.CustType,
                oldCust.Email
                );

            Console.WriteLine("Enter the nubmer of the option you'd like to select:\n" +
                    "1. First Name\n" +
                    "2. Last Name\n" +
                    "3. Customer Type\n" +
                    "4. Email\n" +
                    "5. Nevermind");

            char selection = Console.ReadKey().KeyChar;
            switch (selection)
            {
                case '1':
                    Console.WriteLine("Enter a new Last Name");
                    string newLastName = Console.ReadLine();
                    newCust.LastName = newLastName;


                    bool wasSuccesful = _repo.UpdateCustomerInfo(lastName, oldCust);
                    if (wasSuccesful)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {lastName}");
                    }
                    break;
                case '2':
                    Console.WriteLine("Update Last Name");
                    newCust.LastName = Console.ReadLine();
                    bool nameUpdated = _repo.UpdateCustomerInfo(lastName, oldCust);
                    if (nameUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {lastName}");
                    }
                    break;
                case '3':
                    Console.WriteLine("Update Customer Type: Potential, Current, or Past.");
                    newCust.CustType = Console.ReadLine();
                    bool typeUpdated = _repo.UpdateCustomerInfo(lastName, oldCust);
                    if (typeUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {lastName}");
                    }
                    break;
                case '4':
                    Console.WriteLine("Updated Email");
                    newCust.Email = Console.ReadLine();
                    bool emailUpdated = _repo.UpdateCustomerInfo(lastName, oldCust);
                    if (emailUpdated)
                    {
                        Console.WriteLine("Item successfully updated");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Could not update {lastName}");
                    }
                    break;
                default:
                    break;

            }

        }
        public void DeleteCustomerByLastName()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            ShowAllCustomers();
            Console.WriteLine("Enter Last Name for customer to delete");
            string nameToDelete = Console.ReadLine();

            Customer customerToDelete = _repo.GetCustomerByLastName(nameToDelete);
            bool custDeleted = _repo.DeleteExistingCustomer(customerToDelete);
            if (custDeleted)
            {
                Console.WriteLine("Customer was Deleted");
            }
            else
            {
                Console.WriteLine("Customer was not Deleted");
            }
        }
        private void DisplayCustomers(Customer listContent)
        {
            Console.WriteLine($"{listContent.FirstName,-20}{listContent.LastName,-20}{listContent.CustType,-20}{listContent.Email,-20}");

        }
    }
}
