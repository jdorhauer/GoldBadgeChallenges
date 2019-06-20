using _03_Badges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Comsole
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepo = new BadgeRepository();

        public void Run()
        {
            SeedContentToList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit");

                string response = Console.ReadLine();

                switch (response)
                {
                    case "1":
                        //add
                        AddBadge();
                        break;
                    case "2":
                        bool continueToAdd = true;
                        while (continueToAdd)
                        {
                            Console.Clear();
                            Console.WriteLine("What edit would you like to perform?\n" +
                                "1. Add access to a door\n" +
                                "2. Remove access from a door\n" +
                                "3. Remove all access\n" +
                                "4. Exit");

                            string editResponse = Console.ReadLine();
                            switch (editResponse)
                            {
                                case "1":
                                    //grant single access
                                    NewDoorAccess();
                                    break;
                                case "2":
                                    //remove single access
                                    RemoveADoor();
                                    break;
                                case "3":
                                    //remove all access
                                    RemoveAll();
                                    break;
                                case "4":
                                    continueToAdd = false;
                                    break;
                                default:
                                    Console.WriteLine("Input not recognized.");
                                    break;
                            }
                        }
                        break;
                    case "3":
                        //list all
                        ListAllBadges();
                        break;
                    case "4":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Your input was not recognized. Press any key to go back to the menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void RemoveAll()
        {
            Console.WriteLine("What is the ID number of the badge you would like to remove?");
            int badgeID = int.Parse(Console.ReadLine());
            _badgeRepo.RemoveAllAccess(badgeID);
            Console.WriteLine("Access Removed");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void RemoveADoor()
        {
            Console.WriteLine("What is the ID number of the badge you would like to remove access for?");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the door you would like to remove?");
            string door = Console.ReadLine();

            _badgeRepo.RemoveSingleAccess(badgeID, door);
            Console.WriteLine("Door removed");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void NewDoorAccess()
        {
            Console.WriteLine("What is the ID number of the badge you would like to add access for?");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the door you would like to add?");
            string door = Console.ReadLine();

            _badgeRepo.GiveSingleAccess(badgeID, door);
            Console.WriteLine("Door added");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ListAllBadges()
        {
            Dictionary<int, List<string>> dictionary = _badgeRepo.GetListOfBadges();

            Console.WriteLine("BadgeNumber Doors");

            foreach (KeyValuePair<int, List<string>> pair in dictionary)
            {
                string[] valueArray = pair.Value.ToArray();


                Console.WriteLine("   " + pair.Key.ToString() + "        " + "[{0}]", string.Join(", ", valueArray));
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddBadge()
        {
            Badge newBadge = new Badge();
            List<string> doors = new List<string>();

            Console.WriteLine("What is the ID for the badge you would like to add?");
            newBadge.BadgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to add a door? y/n");
            string userInput = Console.ReadLine();

            while (userInput == "y")
            {
                Console.WriteLine("What door would you like to add?");
                string door = Console.ReadLine();
                doors.Add(door);
                Console.Clear();
                Console.WriteLine("Would you like to add another door? y/n");
                userInput = Console.ReadLine();
            }

            newBadge.AccessibleDoors = doors;

            _badgeRepo.AddBadge(newBadge);
        }

        private void SeedContentToList()
        {
            List<string> doorsOne = new List<string>();
            doorsOne.Add("A1");
            doorsOne.Add("A3");
            doorsOne.Add("D4");
            Badge badge = new Badge(001, doorsOne);
            _badgeRepo.AddBadge(badge);

            List<string> doorsTwo = new List<string>();
            doorsTwo.Add("A3");
            doorsTwo.Add("G37");
            doorsTwo.Add("S45");
            doorsTwo.Add("E4");
            Badge badgeTwo = new Badge(002, doorsTwo);
            _badgeRepo.AddBadge(badgeTwo);

            List<string> doorsThree = new List<string>();
            doorsThree.Add("R3");
            doorsThree.Add("I9");
            doorsThree.Add("Y9");
            doorsThree.Add("A3");
            Badge badgeThree = new Badge(003, doorsThree);
            _badgeRepo.AddBadge(badgeThree);
        }
    }
}
