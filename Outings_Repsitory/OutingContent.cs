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
        public int TotalCostEvent
        {
            get
            {
                return PeopleAttended * TotalCostPerson;
            }
        }
        public OutingContent() { }
        public OutingContent(EventType eventType, int peopleAtt, DateTime dateOfEvent, int totalPerson)
        {
            Event = eventType;
            PeopleAttended = peopleAtt;
            EventDate = dateOfEvent;
            TotalCostPerson = totalPerson;

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
