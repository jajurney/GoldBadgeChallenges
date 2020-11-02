using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInsurance_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> newPremium = new Dictionary<string, int>
            {
                {"Speeding +10", 10 },
                {"Swerved", 50 },
                {"RolledStopSign", 100 },
                {"MaintainSpeed", 100 },
                {"FullStop", 200 }
            };
            string driverHabits = File.ReadAllText("C:/Users/josep/source/repos/GoldBadgeChallenges/SmartInsurance_Console/drivingData.txt");
            string[] premiums = driverHabits.Split(',');
            int basePremium = 100;
            foreach(string premium in premiums)
            {
                if (premium == "Speeding +10")
                {
                    basePremium += 10;
                }
                if(premium == "RolledStopSign")
                {
                    basePremium += 50;
                }
                if (premium == "Swerved")
                {
                    basePremium += 50;
                }
                if(premium == "MaintainSpeed")
                {
                    basePremium -= 150;
                }
                if (premium == "FullStop")
                {
                    basePremium -= 200;
                }
            }
            Console.WriteLine($"Driver's new premium is: ${basePremium}");
            Console.ReadLine();
        }
    }
}
