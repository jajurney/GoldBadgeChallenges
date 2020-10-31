using Outings_Repsitory;
using Outings_Repsitory.Outings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Outings_Console
{
    class ProgramUI
    {
        private OutingContent_Repo _repo = new OutingContent_Repo();

        public void Run()
        {
            OutingsContent();
            Menu();
            Run();
        }
        private void OutingsContent()
        {
            OutingContent golfOuting = new OutingContent(
                EventType.Golf,
                30,
                Convert.ToDateTime("7/15/19"),
                100,
                3000);
            OutingContent bowlingOuting = new OutingContent(
                EventType.Bowling,
                25,
                Convert.ToDateTime("8/9/2019"),
                200,
                5000);
            OutingContent amusemnetOuting = new OutingContent(
               EventType.AmusmentPark,
               20,
               Convert.ToDateTime("10/13/2019"),
               150,
               3000);
            OutingContent concertOuting = new OutingContent(
                EventType.Concert,
                35,
                Convert.ToDateTime("12/15/2019"),
                250,
                8750);
            OutingContent concertOutingTwo = new OutingContent(
                   EventType.Concert,
                   20,
                   Convert.ToDateTime("3/3/2019"),
                   300,
                   6000);
            _repo.AddOutingToList(golfOuting);
            _repo.AddOutingToList(bowlingOuting);
            _repo.AddOutingToList(amusemnetOuting);
            _repo.AddOutingToList(concertOuting);
            _repo.AddOutingToList(concertOutingTwo);
        }
        private void Menu()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                Console.Clear();

                Console.WriteLine("Enter your selection:\n" +
                    "1. Show all Outings\n" +
                    "2. Find an Outing By Date\n" +
                    "3. Add a New Outing\n" +
                    "4. Update existing Outings\n" +
                    "5. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        ShowOutingByDate();
                        break;
                    case "3":
                        CreateNewOuting();
                        break;
                    case "4":
                        UpdateExistingOutingContentByDate();
                        break;
                    case "5":
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a different option");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private void ShowAllOutings()
        {
            Console.Clear();

            List<OutingContent> listOfOutings = _repo.GetOutingContents();

            foreach (OutingContent outingContent in listOfOutings)
            {
                DisplayContent(outingContent);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void CreateNewOuting()
        {
            Console.Clear();

            OutingContent newOutingContent = new OutingContent();

            bool stopRunning = false;
            while (!stopRunning)
            {
                Console.WriteLine("Enter Outing Type:");
                Console.WriteLine("1. Concert");
                Console.WriteLine("2. Golf");
                Console.WriteLine("3. Bowling");
                Console.WriteLine("4. Amusment Park");
                string eventType = Console.ReadLine();
                switch (eventType)
                {
                    case "1":
                        newOutingContent.Event = EventType.Concert;
                        break;
                    case "2":
                        newOutingContent.Event = EventType.Golf;
                        break;
                    case "3":
                        newOutingContent.Event = EventType.Bowling;
                        break;
                    case "4":
                        newOutingContent.Event = EventType.AmusmentPark;
                        break;
                    default:
                        Console.WriteLine("Please enter a correct option.");
                        stopRunning = true;
                        break;
                }
                Console.WriteLine("How many people Attentend?");
                string peopleAsString = Console.ReadLine();
                int peopleAsInt = int.Parse(peopleAsString);
                newOutingContent.PeopleAttended = peopleAsInt;

                Console.WriteLine("What was the date of the Event?");
                string dateAsString = Console.ReadLine();
                DateTime dateAsDate = DateTime.Parse(dateAsString);
                newOutingContent.EventDate = dateAsDate;

                Console.WriteLine("How much per person?");
                string costAsString = Console.ReadLine();
                int costAsInt = int.Parse(costAsString);
                newOutingContent.TotalCostPerson = costAsInt;
                //Addition?
                Console.WriteLine("How much was the event Total?");
                string totalAsString = Console.ReadLine();
                int totalAsInt = int.Parse(totalAsString);
                newOutingContent.TotalCostEvent = totalAsInt;


            }
            bool outingAdded = _repo.AddOutingToList(newOutingContent);
            if (outingAdded)
            {
                Console.WriteLine("The New Outing was Added Successfully!");
            }
            else
            {
                Console.WriteLine("Outing not add something has gone wrong.");
            }
        }
        private void ShowOutingByDate()
        {
            Console.Clear();
            Console.WriteLine("Enter the date of the outing you would like to see.");
            string dateAsString = Console.ReadLine();
            DateTime dateOfEvent = DateTime.Parse(dateAsString);

            _repo.GetOutingByDate(dateOfEvent);
            OutingContent outingContent = _repo.GetOutingByDate(dateOfEvent);
            if (outingContent != null)
            {
                DisplayContent(outingContent);
            }
            else
            {
                Console.WriteLine("That does not exits in the List");
            }
            Console.ReadKey();
        }
        private void UpdateExistingOutingContentByDate()
        {
            Console.Clear();
            Console.WriteLine("Enter the date of the Outing you would like to update.");
            string dateAsString = Console.ReadLine();
            DateTime dateOfEvent = DateTime.Parse(dateAsString);
            OutingContent oldContent = _repo.GetOutingByDate(dateOfEvent);
            if (oldContent == null)
            {
                Console.WriteLine("Outing could not be found.");
                Console.ReadKey();
                return;
            }
            OutingContent newContent = new OutingContent(
                oldContent.Event,
                oldContent.PeopleAttended,
                oldContent.EventDate,
                oldContent.TotalCostPerson,
                oldContent.TotalCostEvent);
            Console.WriteLine("Enter the number option you would like to select:\n" +
                "1. Event Type\n" +
                "2. People Attended\n" +
                "3. Event Date\n" +
                "4. Cost Per Person\n" +
                "5. Total Cost of Outing");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    bool stopRunning = false;
                    while (!stopRunning)
                    {
                        Console.WriteLine("Enter Outing Type:");
                        Console.WriteLine("1. Concert");
                        Console.WriteLine("2. Golf");
                        Console.WriteLine("3. Bowling");
                        Console.WriteLine("4. Amusment Park");
                        string eventType = Console.ReadLine();
                        switch (eventType)
                        {
                            case "1":
                                newContent.Event = EventType.Concert;
                                break;
                            case "2":
                                newContent.Event = EventType.Golf;
                                break;
                            case "3":
                                newContent.Event = EventType.Bowling;
                                break;
                            case "4":
                                newContent.Event = EventType.AmusmentPark;
                                break;
                            default:
                                Console.WriteLine("Please enter a correct option.");
                                stopRunning = true;
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Update Attendance");
                    string peopleAsString = Console.ReadLine();
                    int peopleAsInt = int.Parse(peopleAsString);
                    newContent.PeopleAttended = peopleAsInt;
                    break;
                case "3":
                    Console.WriteLine("New Event Date?");
                    string dateString = Console.ReadLine();
                    DateTime dateAsDate = DateTime.Parse(dateString);
                    newContent.EventDate = dateAsDate;
                    break;
                case "4":
                    Console.WriteLine("New Cost Per Person?");
                    string costAsString = Console.ReadLine();
                    int costAsInt = int.Parse(costAsString);
                    newContent.TotalCostPerson = costAsInt;
                    break;
                case "5":
                    Console.WriteLine("New Event Total?");
                    string totalAsString = Console.ReadLine();
                    int totalAsInt = int.Parse(totalAsString);
                    newContent.TotalCostEvent = totalAsInt;
                    break;
                default:
                    break;

            }
        }

        private void DisplayContent(OutingContent outingContent)
        {
          
            Console.WriteLine($"{outingContent.Event,-20}{outingContent.PeopleAttended,-20}{outingContent.EventDate,-20}{outingContent.TotalCostPerson,20}{outingContent.TotalCostEvent,20}");
        }



    }
}
