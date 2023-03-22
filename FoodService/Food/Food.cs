using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LifeConsolidated.FoodService.Food{

[Table("Foods")]
    public class Food
    {
        [Key]
        [Column("FoodId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Column("FoodName")]
        public string Name { get; set; }
        
        [Column("FoodType")]
        public FoodKind Type { get; set; }

        [Column("Description")]
        [DefaultValue(" ")]
        public string Description { get; set; } = "";
        
        [Column("Calories")]
        public int Calories { get; set; }
        
        [Column("Protein")]
        public int Protein { get; set; }
        
        [Column("Fat")]
        public int Fat { get; set; }
        
        [Column("Carbohydrates")]
        public int Carbohydrates { get; set; }

        [Column("DateCreated")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Timestamp]
        public DateTime DateCreated { get; set; }

        [Column("DateLastUpdated")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Timestamp]
        public DateTime DateLastUpdated { get; set; }

        //Constructor WITHOUT description
        public Food(string name, FoodKind type, int calories, int protein, int fat, int carbohydrates)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
        }

        //Constructor WITH description
        public Food(string name, FoodKind type, int calories, int protein, int fat, int carbohydrates, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            Calories = calories;
            Protein = protein;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Description = description;
        }

        //public Food() { }
    }
}