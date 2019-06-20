using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private Badge _badge;
        private Badge _badgeTwo;
        private BadgeRepository _badgeRepo;

        [TestInitialize]
        public void Arrange()
        {
            List<string> doors = new List<string>();
            doors.Add("A1");
            doors.Add("A5");
            doors.Add("B3");
            doors.Add("C73");

            List<string> doorsTwo = new List<string>();
            doorsTwo.Add("A1");
            doorsTwo.Add("T7");
            doorsTwo.Add("E15");

            _badgeRepo = new BadgeRepository();
            _badge = new Badge(001, doors);
            _badgeTwo = new Badge(002, doorsTwo);

            _badgeRepo.AddBadge(_badge);
            _badgeRepo.AddBadge(_badgeTwo);
        }

        [TestMethod]
        public void AddBadgeTest()
        {
            int expected = 2;
            int actual = _badgeRepo.GetListOfBadges().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveAllTest()
        {
            _badgeRepo.RemoveAllAccess(_badgeTwo.BadgeID);

            int expected = 1;
            int actual = _badgeRepo.GetListOfBadges().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GiveSingleTest()
        {
            _badgeRepo.GiveSingleAccess(002, "J28");

            int expected = 4;
            int actual = _badgeRepo.GetListOfDoors().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveSingleTest()
        {
            _badgeRepo.RemoveSingleAccess(001, "A5");

            int expected = 3;
            int actual = _badgeRepo.GetListOfDoors().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
