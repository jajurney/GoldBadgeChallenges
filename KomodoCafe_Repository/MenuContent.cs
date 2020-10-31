using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repository
{
    public class MenuContent
    {
        public int MealNum { get; set; }
        public string MealItem { get; set; }
        public string MealDescription { get; set; }
        public double MealPrice { get; set; }

        public string Ingredients{ get; set; }


        public MenuContent() { }
        public MenuContent(int mealNum, string mealItem, string mealDescription, double mealPrice, string ingredient)
        {
            MealNum = mealNum;
            MealItem = mealItem;
            MealDescription = mealDescription;
            MealPrice = mealPrice;
            Ingredients = ingredient;
        }

      
    }


}
