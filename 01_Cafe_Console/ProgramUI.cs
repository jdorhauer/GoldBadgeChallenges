using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    class ProgramUI
    {
        MenuRepository _menuRepo = new MenuRepository();

        public void Run()
        {
            SeedContentList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1. View Menu Items\n" +
                    "2. Add Menu Item\n" +
                    "3. Remove Menu Item\n" +
                    "4. Exit");

                string userResponse = Console.ReadLine();

                switch (userResponse)
                {
                    case "1":
                        //view items
                        ViewFullMenu();
                        break;
                    case "2":
                        //add item
                        AddItem();
                        break;
                    case "3":
                        //remove item
                        RemoveItem();
                        break;
                    case "4":
                        //exit
                        continueToRunMenu = false;
                        break;
                    default:
                        Console.WriteLine("Response not recognized...");
                        break;
                }
            }
        }

        private void RemoveItem()
        {
            Console.Write("What is the item number that you would like to remove? ");
            int mealNumber = int.Parse(Console.ReadLine());

            Menu item = _menuRepo.GetItemByNumber(mealNumber);

            _menuRepo.RemoveMenuItem(item);

            Console.WriteLine("The item has been removed. Press any key to continue...");
            Console.ReadKey();
        }

        private void AddItem()
        {
            Menu newItem = new Menu();

            Console.Write("What is the menu item number? ");
            newItem.MealNumber = int.Parse(Console.ReadLine());

            Console.Write("What is the item's name? ");
            newItem.Name = Console.ReadLine();

            Console.Write("What is a brief description of the item? ");
            newItem.Description = Console.ReadLine();

            Console.Write("What ingredients are used in this item? ");
            newItem.Ingredients = Console.ReadLine();

            Console.Write("What is the price? ");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            _menuRepo.AddMenuItem(newItem);

            Console.WriteLine("The item has been added. Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewFullMenu()
        {
            List<Menu> listOfMenuItems = _menuRepo.GetListOfItems();

            foreach(Menu item in listOfMenuItems)
            {
                Console.WriteLine($"{item.MealNumber} - {item.Name} - {item.Price}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedContentList()
        {
            Menu burger = new Menu(01, "burger", "The best burger there is.", "bun, beef, seasonings, lettuce, tomato", 25.75);
            Menu chickenStrips = new Menu(02, "Chicken Strips", "strips of chicken", "flour, salt, pepper, chicken", 15.43);
            Menu salad = new Menu(03, "Salad", "uncle vernon's rabbit food", "lettuce, carrot, bell pepper, onion, dressing", 10.23);

            _menuRepo.AddMenuItem(burger);
            _menuRepo.AddMenuItem(chickenStrips);
            _menuRepo.AddMenuItem(salad);
        }
    }
}
