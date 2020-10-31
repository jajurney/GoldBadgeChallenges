using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Outings_Repsitory.Outings
{
    public class OutingContent
    {
        public string EventType { get; set; } 
        public int PeopleAttended { get; set; }
        public DateTime EventDate { get; set; } = new DateTime();
        public int TotalCostPerson { get; set; }
        public int TotalCostEvent { get; set; }

       
        
        public OutingContent() { }
        public OutingContent(string eventType, int peopleAtt, DateTime dateOfEvent, int totalPerson, int totalEvent)
        {
            EventType = eventType;
            PeopleAttended = peopleAtt;
            EventDate = dateOfEvent;
            TotalCostPerson = totalPerson;
            TotalCostEvent = totalEvent;
        }
        
       
       
    }
}
