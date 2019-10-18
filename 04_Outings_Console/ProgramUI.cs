using _04_Outings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings_Console
{
    class ProgramUI
    {
        OutingRepository _outingRepo = new OutingRepository();

        public void Run()
        {
            SeedContentToList();
            RunMenu();
        }

        public void RunMenu()
        {

        }

        public void SeedContentToList()
        {
            Outing outingOne = new Outing(EventType.AmusementPark, 15, DateTime.Parse("05/18/2019"), 35);
            Outing outingTwo = new Outing(EventType.Golf, 13, DateTime.Parse("03/02/2019"), 25);
            Outing outingThree = new Outing(EventType.Bowling, 10, DateTime.Parse("07/27/2019"), 15);

            _outingRepo.AddOuting(outingOne);
            _outingRepo.AddOuting(outingTwo);
            _outingRepo.AddOuting(outingThree);
        }
    }
}
