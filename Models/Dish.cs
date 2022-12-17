#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace RichChefsAndDishes.Models;
public class Dish
{
    [Key]
    public int DishId { get; set; }
    [Required(ErrorMessage = "Dish name is required.")]
    public string DishName { get; set; }
    [Required(ErrorMessage = "Number of Calories is required.")]
    [Range(1, Int32.MaxValue, ErrorMessage = "Cannot be 0 calories.")]
    public int Calories { get; set; }
    [Required(ErrorMessage = "Tastiness is required.")]
    public int Tastiness { get; set; }

    //chef
    public int ChefId { get; set; }
    public Chef? Chef { get; set; }
}