using LifeConsolidated.FoodService.Food;

namespace LifeConsolidated.ConsoleApplicationService;

public static class Menus {
    
    //This is de facto the entire Console Application - Main shall just call the MainMenu();
    public static void MainMenu() {
        
        DatabaseConnection context = new DatabaseConnection();
        FoodAction foodAction = new FoodAction(context);
        context.Database.EnsureCreated();
        
        while (true)
        {
            Console.WriteLine("\nBIENVENUE to LifeConsolidated\nPlease select an option:");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Add Food to Database   2. Display Table - Foods");
            Console.WriteLine("3. Option 3               4. Option 4");
            Console.WriteLine("5. Option 5               6. Option 6");
            Console.WriteLine("7. Option 7               8. Option 8");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("9. Populate Foods-table with test data");
            Console.WriteLine("0. EXIT");
            Console.WriteLine("-----------------------------------------");


            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Choice.AddFoodChoice(foodAction);
                    break;
                case "2":
                    Console.Clear();
                    Choice.DisplayFoodsTable(foodAction);
                    // Call function for choice 2
                    break;
                case "3":
                    // Call function for choice 3
                    break;
                case "4":
                    // Call function for choice 4
                    break;
                case "5":
                    // Call function for choice 5
                    break;
                case "6":
                    // Call function for choice 6
                    break;
                case "7":
                    // Call function for choice 7
                    break;
                case "8":
                    // Call function for choice 7
                    break;
                case "9":
                    Console.Clear();
                    Choice.PopulateFoodTableTestData(foodAction);
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("INVALID CHOICE! Please try again.");
                    break;
            }
        }
    }
}