 using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Outings_Repsitory.Outings
{
    public class OutingContent
    {
        public EventType Event { get; set; } 
        public int PeopleAttended { get; set; }
        public DateTime EventDate { get; set; }
        public int TotalCostPerson { get; set; }
        //Addition
        public int TotalCostEvent { get; set; }
        

       
        
        public OutingContent() { }
        public OutingContent(EventType eventType, int peopleAtt, DateTime dateOfEvent, int totalPerson, int totalEvent)
        {
            Event = eventType;
            PeopleAttended = peopleAtt;
            EventDate = dateOfEvent;
            TotalCostPerson = totalPerson;
            TotalCostEvent = totalEvent;
        }
        
       
       
    }
    public enum EventType
    {
        Concert,
        Golf,
        Bowling,
        AmusmentPark
    }
   
}
