using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Repository
{
    public class OutingRepository
    {
        List<Outing> _outings = new List<Outing>();

        // Display all
        public List<Outing> DisplayOutings()
        {
            return _outings;
        }

        // Add outings to list
        public void AddOuting(Outing outing)
        {
            _outings.Add(outing);
        }

        // calculate combined cost for each type of outing
        public decimal CalculateCostByEventType(EventType eventType)
        {
            decimal total = 0;
            foreach (Outing outing in _outings)
            {
                if (outing.TypeOfEvent == eventType)
                {
                    total += outing.TotalCost;
                }
            }
            return total;
        }

        // combine cost for all outings
        public decimal TotalOutingsCost()
        {
            decimal total = 0;

            foreach (Outing outing in _outings)
            {
                total += outing.TotalCost;
            }
            return total;
        }
    }
}
