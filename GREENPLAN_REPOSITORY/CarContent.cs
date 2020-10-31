using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GREENPLAN_REPOSITORY
{
    public class CarContent
    {

        public string PowerType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public CarType CarType { get; set;}
        public CarBody CarBody { get; set;}

        public CarContent() { }
        public CarContent(string power, string make, string model, int year, CarType carType, CarBody carBody)
        {
            PowerType = power;
            Make = make;
            Model = model;
            Year = year;
            CarType = carType;
            CarBody = carBody;
        }
       
            
        }
        public enum  CarType
        {
            Electric,
            Gas,
            Hybrid
        }
        public enum CarBody
            {
                SUV,
                sedan,
                truck,
                coupe
            }
}
