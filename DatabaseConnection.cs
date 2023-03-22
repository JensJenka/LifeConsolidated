using LifeConsolidated.FoodService.Food;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LifeConsolidated;

public class DatabaseConnection : DbContext
{
    //DbContext contains DbSet<Food> property that represents the collection of foods in the database.
    public DbSet<Food> Foods { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>()
            .HasKey(f => f.Id)
            .HasName("PK_Foods");

        modelBuilder.Entity<Food>()
            .Property(f => f.Name)
            .HasColumnName("FoodName")
            .IsRequired();

        modelBuilder.Entity<Food>()
            .Property(f => f.Type)
            .HasColumnName("FoodType");

        modelBuilder.Entity<Food>()
            .Property(f => f.Description)
            .HasColumnName("Description")
            .IsRequired(false);

        modelBuilder.Entity<Food>()
            .Property(f => f.Calories)
            .HasColumnName("Calories");

        modelBuilder.Entity<Food>()
            .Property(f => f.Protein)
            .HasColumnName("Protein");

        modelBuilder.Entity<Food>()
            .Property(f => f.Fat)
            .HasColumnName("Fat");

        modelBuilder.Entity<Food>()
            .Property(f => f.Carbohydrates)
            .HasColumnName("Carbohydrates");

        modelBuilder.Entity<Food>()
            .Property(f => f.DateCreated)
            .HasColumnName("DateCreated")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Food>()
            .Property(f => f.DateLastUpdated)
            .HasColumnName("DateLastUpdated")
            .ValueGeneratedOnAdd();
    }

    //OnConfiguring method sets the database provider and connection string.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        if (!File.Exists(appSettingsPath))
        {
            throw new FileNotFoundException("The appsettings.json file was not found to ensure database connection.", appSettingsPath);
        }
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        string mysqlConnectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseMySQL(mysqlConnectionString);
    }
}