﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Repository
{
    public class Claim
    {
        public enum ClaimType { Car = 1, Home, Theft }

        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim() { }

        public Claim(int claimID, ClaimType typeOfClaim, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            TypeOfClaim = typeOfClaim;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
