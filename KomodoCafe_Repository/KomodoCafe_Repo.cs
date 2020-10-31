using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class KomodoCafe_Repo
    {
        private  List<MenuContent> _menuContents = new List<MenuContent>();

        
        public bool AddItemToMenu(MenuContent menuContent)
        {
            int itemCount = _menuContents.Count;
            _menuContents.Add(menuContent);
            bool itemAdded = (_menuContents.Count > itemCount) ? true : false;
            return itemAdded;
        }
        public List<MenuContent> GetMenu()
        {
            return _menuContents;
            
        }
       
        public MenuContent GetItemByMealName(string menuItem)
        {
            foreach (MenuContent menuContent in _menuContents)
            {
                if (menuContent.MealItem.ToLower() == menuItem)
                {
                    return menuContent;
                }
            }
            return null;
        }
       
      
        
       
        public bool UpdateMenuItems(string originalItem, MenuContent newItem)
        {
            MenuContent oldItem = GetItemByMealName(originalItem);
            if (oldItem != null)
            {
                oldItem.MealNum = newItem.MealNum;
                oldItem.MealItem = newItem.MealItem;
                oldItem.MealDescription = newItem.MealDescription;
                oldItem.MealPrice = newItem.MealPrice;
                oldItem.Ingredients = newItem.Ingredients;
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool DeleteMenuItem(MenuContent existingItem)
        {
            bool deleteItem = _menuContents.Remove(existingItem);
            return true;
        }
    }
}
