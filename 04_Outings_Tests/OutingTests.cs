using System;
using _04_Outings_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_Outings_Tests
{
    [TestClass]
    public class OutingTests
    {
        private OutingRepository _outingRepo;
        private Outing _outingOne;
        private Outing _outingTwo;
        private Outing _outingThree;

        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepository();
            _outingOne = new Outing(EventType.Golf, 4, DateTime.Parse("03/12/2019"), 15);
            _outingTwo = new Outing(EventType.Golf, 7, DateTime.Parse("07/23/2019"), 10);
            _outingThree = new Outing(EventType.Bowling, 9, DateTime.Parse("11/05/2018"), 13);

            _outingRepo.AddOuting(_outingOne);
            _outingRepo.AddOuting(_outingTwo);
            _outingRepo.AddOuting(_outingThree);
        }

        [TestMethod]
        public void OutingAddTest()
        {
            int expected = 3;
            int actual = _outingRepo.DisplayOutings().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void CostByEventTest()
        {
            decimal expected = 130;
            decimal actual = _outingRepo.CalculateCostByEventType(EventType.Golf);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TotalCostTest()
        {
            decimal expected = 247;
            decimal actual = _outingRepo.TotalOutingsCost();

            Assert.AreEqual(expected, actual);
        }
    }
}
