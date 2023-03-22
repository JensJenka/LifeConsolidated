namespace LifeConsolidated.FoodService.Food;

public class FoodAction
{
    private readonly DatabaseConnection _databaseContext;

    public FoodAction(DatabaseConnection context)
    {
        _databaseContext = context;
        _databaseContext.Database.EnsureCreated();
    }
//-------------------------------------------------------------------------------
    public List<Food> GetAllFoods()
    {
        return _databaseContext.Foods.ToList();
    }
    
    public List<Food> SearchFoodByFoodName(string FoodName)
    {
        return _databaseContext.Foods.Where(f => f.Name.ToLower().Contains(FoodName.ToLower())).ToList();
    }
    
    /*
    public List<Food> GetFoodsByCategory(FoodKind category)
    {
        return _databaseContext.Foods.Where(f => f.Category == category).ToList();
    } */  


    public Food GetFoodById(int id)
    {
        return _databaseContext.Foods.FirstOrDefault(f => f.Id == id);
    }

    public void AddFood(Food food)
    {
        _databaseContext.Foods.Add(food);
        _databaseContext.SaveChanges();
    }

    public void UpdateFood(Food food)
    {
        _databaseContext.Foods.Update(food);
        _databaseContext.SaveChanges();
    }

    public void DeleteFood(int id)
    {
        var food = _databaseContext.Foods.FirstOrDefault(f => f.Id == id);
        if (food != null)
        {
            _databaseContext.Foods.Remove(food);
            _databaseContext.SaveChanges();
        }
    }
    
    public List<Food> GetFoodsByCalories(int minCalories, int maxCalories)
    {
        if (minCalories < 0 || maxCalories < 0)
        {
            throw new ArgumentException("Calorie values cannot be negative.");
        }
        if (minCalories > maxCalories)
        {
            throw new ArgumentException("Minimum calorie value cannot be greater than maximum calorie value.");
        }
        if (minCalories == 0 && maxCalories == 0)
        {
            return _databaseContext.Foods.ToList();
        }
        return _databaseContext.Foods.Where(f => f.Calories >= minCalories && f.Calories <= maxCalories).ToList();
    }
    
    public void DeleteFoodOnFoodName(string foodName)
{
    try
    {
        var food = _databaseContext.Foods.FirstOrDefault(f => f.Name == foodName);
        if (food != null)
        {
            _databaseContext.Foods.Remove(food);
            _databaseContext.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Food with the specified name not found.");
        }
    }
    catch (Exception ex)
    {
        throw new Exception("An error occurred while deleting the food.", ex);
    }
}
}