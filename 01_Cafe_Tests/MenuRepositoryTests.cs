using System;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        private MenuRepository _menuRepo;
        private Menu _item;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new MenuRepository();
            _item = new Menu(01, "burger", "The most delicious burger ever.", "bread, beef, seasoning, ketchup", 35.75);

            _menuRepo.AddMenuItem(_item);
        }


        [TestMethod]
        public void AddMenuItemTest()
        {
            int expected = 1;
            int actual = _menuRepo.GetListOfItems().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteMenuItemTest()
        {
            _menuRepo.RemoveMenuItem(_item);
            int expected = 0;
            int actual = _menuRepo.GetListOfItems().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void GetItemByNumberTest()
        {
            Menu menuItem = _menuRepo.GetItemByNumber(01);

            Assert.AreEqual(menuItem.Name, "burger");
        }
    }
}
