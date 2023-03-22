using LifeConsolidated.ConsoleApplicationService;
using LifeConsolidated.FoodService.Food;
using Microsoft.EntityFrameworkCore;

namespace LifeConsolidated;

static class Index
{
    private static void Main(string[] args) {
        
        Menus.MainMenu();
    }
}
/*
        Food food3 = new Food("Green Smoothie", FoodKind.Beverages, 150, 5, 2, 30, "Spinach, kale, banana, almond milk, and honey blended together.");
        foodAction.AddFood(food3);

        Food food4 = new Food("Pesto Pasta", FoodKind.Carbz, 400, 15, 20, 50, "Fusilli pasta, basil pesto, cherry tomatoes, and parmesan cheese.");
        foodAction.AddFood(food4);

        Food food5 = new Food("Chocolate Chip Cookie", FoodKind.Sweets, 200, 2, 10, 30, "Soft and chewy cookie loaded with chocolate chips.");
        foodAction.AddFood(food5);
*/
        

