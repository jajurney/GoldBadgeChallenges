using System;

namespace Outings.Outing_Types
{
    public interface IOutings
    {
        string EventType { get; }
        int PeopleAttended { get; }
        DateTime EventDate { get; }
        double TotalCostPerson { get; }
        double TotalCostEvent { get; }
    }
}
