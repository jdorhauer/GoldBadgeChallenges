using _02_Komodo_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Console
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            SeedContentToMenu();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. See all claims\n" +
                    "2. Add a new claim\n" +
                    "3. Take the next claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //see all
                        SeeAllClaims();
                        break;
                    case "2":
                        //add
                        AddNewClaim();
                        break;
                    case "3":
                        //take next
                        TakeNextClaim();
                        break;
                    case "4":
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Your input was not recognized. Please enter 1-4...");
                        break;
                }
            }
        }

        private void TakeNextClaim()
        {
            Claim nextClaim = _claimRepo.ViewNextClaim();
            Console.WriteLine($"Here are the details of the next claim.\n" +
                $"Claim ID: {nextClaim.ClaimID}\n" +
                $"ClaimType: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"ClaimAmount: {nextClaim.ClaimAmount}\n" +
                $"DateOfIncident: {nextClaim.DateOfIncident.ToShortDateString()}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n" +
                $"Would you like to work this claim now? y/n");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "y":
                    _claimRepo.TakeNextClaim();
                    Console.WriteLine("The claim is now in your queue.");
                    break;
                case "n":
                    break;
                default:
                    Console.WriteLine("Input not recognized.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        private void AddNewClaim()
        {
            Claim newClaim = new Claim();

            Console.WriteLine("What is the claim number?");
            newClaim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the type of claim?\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            int type = int.Parse(Console.ReadLine());
            newClaim.TypeOfClaim = (Claim.ClaimType)type;

            Console.WriteLine("What is a description of the claim?");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("What is the amount of the claim?");
            newClaim.ClaimAmount = Decimal.Parse(Console.ReadLine());

            Console.WriteLine("What was the date of the incident?");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("What is the date the claim was filed?");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            _claimRepo.AddClaimToQueue(newClaim);

            Console.Write("The claim has been added.\n" +
                "Press any key to tontinue...");
            Console.ReadKey();
        }

        private void SeeAllClaims()
        {
            Queue<Claim> queueOfClaims = _claimRepo.GetListOfClaims();

            Console.WriteLine("ClaimID  ClaimType  ClaimDescription     ClaimAmount    DateOfIncident   DateOfClaim     IsValid");

            foreach(Claim claim in queueOfClaims)
            {
                Console.WriteLine($" {claim.ClaimID}       {claim.TypeOfClaim}       {claim.Description}     {claim.ClaimAmount}       {claim.DateOfIncident.ToShortDateString()}        {claim.DateOfClaim.ToShortDateString()}        {claim.IsValid}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedContentToMenu()
        {
            Claim autoClaim = new Claim(1, Claim.ClaimType.Car, "accident on 70 west", 250.00m, new DateTime(2019, 05, 26), new DateTime(2019, 06, 07));
            Claim houseClaim = new Claim(2, Claim.ClaimType.Home, "tree fell on roof", 4000.00m, new DateTime(2019, 04, 18), new DateTime(2019, 05, 27));
            Claim theftClaim = new Claim(3, Claim.ClaimType.Theft, "property break in", 1500.00m, new DateTime(2019, 06, 14), new DateTime(2019, 06, 17));

            _claimRepo.AddClaimToQueue(autoClaim);
            _claimRepo.AddClaimToQueue(houseClaim);
            _claimRepo.AddClaimToQueue(theftClaim);
        }
    }
}
