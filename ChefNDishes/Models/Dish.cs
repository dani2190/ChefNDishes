using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models
{
    public class Dish
    {
        [Key]
        [Required(ErrorMessage = "Dish Name is required")]
        [Display(Name = "Name of Dish:")]
        public string DishName {get; set;}
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Calories is required")]
        [Display(Name = "Calories:")]
        [Range(1, int.MaxValue,ErrorMessage = "Calories must be greater then 0")]
        public int Calories { get; set; }
        [Required(ErrorMessage = "Tastiness is required")]
        [Display(Name = "Tastiness:")]
        [Range(1, 5)]
        public int Tastiness { get; set; }
        public int ChefId { get; set; }
        public Chef Creator { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}