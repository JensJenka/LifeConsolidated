using LifeConsolidated.FoodService.Food;

namespace LifeConsolidated.ConsoleApplicationService;

public static class Choice
{
    //Choice 1 
    public static void AddFoodChoice(FoodAction foodAction)
    {
        string foodName;
        do
        {
            Console.WriteLine("You have chosen to add a food - What is its name?: ");
            foodName = Console.ReadLine()!;
        } while (string.IsNullOrEmpty(foodName));
        FoodKind foodKind;
        
        while (true)
        {
            Console.WriteLine("Categories to choose from: Dairy, Meat, Carbz, Vegetables, Fruits, Legumes, NutsAndSeeds, Beverages, Sweets, Snacks, Condiments, OilsAndFats");
            Console.WriteLine("What kind of food is it?");
            string foodKindInput = Console.ReadLine()!;
            if (Enum.TryParse(foodKindInput, out foodKind))
            {
                Console.WriteLine($"\nFood kind {foodKind} selected.");
                break;
            }
            Console.WriteLine($"\nInvalid food kind: {foodKindInput}. Please chose from the list.");
        }
                    
        Console.WriteLine("Please enter the number of calories: ");
        int calories = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Please enter the number of grams of protein: ");
        int protein = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Please enter the number of grams of fat: ");
        int fat = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine("Please enter the number of grams of carbohydrates: ");
        int carbz = int.Parse(Console.ReadLine() ?? "0");
        Food newFood = new Food(foodName, foodKind, calories, protein, fat, carbz);
        foodAction.AddFood(newFood);
        
        Console.Clear();
        Console.WriteLine("\rFood successfully added! - 'Jenka'");
    }
    
    //Choice 2
    public static void DisplayFoodsTable(FoodAction foodAction)
    {
        List<Food> foods = foodAction.GetAllFoods();

        Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-10} {4,-10} {5,-10} {6,-10}", "\nID", "Name", "FoodKind", "Calories", "Protein", "Fat", "Carbz");
        Console.WriteLine(new string('-', 100));

        foreach (Food food in foods)
        {
            Console.WriteLine("{0,-5} {1,-30} {2,-20} {3,-10} {4,-10} {5,-10} {6,-10}",
                food.Id, food.Name, food.Type, food.Calories, food.Protein, food.Fat, food.Carbohydrates);
        }
    }
    
    //Choice 9
    public static void PopulateFoodTableTestData(FoodAction foodAction)
    {
        Console.WriteLine("\nTest Data INSERTED");
        Food testFood1 = new Food("Grilled Chicken Salad", FoodKind.Vegetables, 300, 30, 10, 20, "Mixed greens, grilled chicken, cherry tomatoes, cucumbers, and balsamic vinaigrette dressing.");
        Food testFood2 = new Food("Salmon Sushi Roll", FoodKind.Meat, 250, 20, 10, 30);
        foodAction.AddFood(testFood2);
        foodAction.AddFood(testFood1);
    }

    
}