using System;
using _02_Komodo_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Komodo_Tests
{
    [TestClass]
    public class ClaimTests
    {
        private ClaimRepository _queueOfClaims;
        private Claim _claim;
        private Claim _lateClaim;

        [TestInitialize]
        public void Arrange()
        {
            _queueOfClaims = new ClaimRepository();
            _claim = new Claim(1, Claim.ClaimType.Car, "accident on 465", 4000.00m, Convert.ToDateTime("06/02/2019"), Convert.ToDateTime("06/17/2019"));
            _lateClaim = new Claim(2, Claim.ClaimType.Home, "tornado damage to roof", 3000.00m, new DateTime(2019, 04, 03), new DateTime(2019, 06, 14));
        }

        [TestMethod]
        public void DateTests()
        {
            DateTime actual = _claim.DateOfIncident;
            DateTime expected = new DateTime(06 / 02 / 2019);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void IsValidTest()
        {
            _queueOfClaims.AddClaimToQueue(_claim);
            bool actual = _claim.IsValid;
            bool expected = true;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void IsValidTestTwo()
        {
            _queueOfClaims.AddClaimToQueue(_lateClaim);
            bool lateActual = _lateClaim.IsValid;
            bool lateExpected = false;

            Assert.AreEqual(lateActual, lateExpected);
        }

        [TestMethod]
        public void AddToQueueTest()
        {
            _queueOfClaims.AddClaimToQueue(_claim);
            int actual = _queueOfClaims.GetListOfClaims().Count;

            int expected = 1;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewNextClaimTest()
        {
            _queueOfClaims.AddClaimToQueue(_claim);
            Claim actual = _queueOfClaims.ViewNextClaim();
            Claim expected = _claim;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TakeNextClaimTest()
        {
            _queueOfClaims.AddClaimToQueue(_claim);
            _queueOfClaims.TakeNextClaim();

            int actual = _queueOfClaims.GetListOfClaims().Count;
            int expected = 0;

            Assert.AreEqual(actual, expected);
        }
    }
}
