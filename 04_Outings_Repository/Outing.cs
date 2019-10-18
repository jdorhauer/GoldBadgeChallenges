using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Repository
{
    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert}

    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int Attendance { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal TotalCost { get; set; }

        public Outing() { }

        public Outing(EventType typeOfEvent, int attendance, DateTime date, decimal costPerPerson)
        {
            TypeOfEvent = typeOfEvent;
            Attendance = attendance;
            Date = date;
            CostPerPerson = costPerPerson;
            TotalCost = costPerPerson * attendance;
        }
    }
}
