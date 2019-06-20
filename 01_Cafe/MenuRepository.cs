using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        private List<Menu> _listOfMenuItems = new List<Menu>();

        public void AddMenuItem(Menu item)
        {
            _listOfMenuItems.Add(item);
        }

        public List<Menu> GetListOfItems()
        {
            return _listOfMenuItems;
        }

        public Menu GetItemByNumber(int mealNumber)
        {
            foreach(Menu item in _listOfMenuItems)
            {
                if(mealNumber == item.MealNumber)
                {
                    return item;
                }
            }

            return null;
        }

        public void RemoveMenuItem(Menu item)
        {
            _listOfMenuItems.Remove(item);
        }
    }
}
