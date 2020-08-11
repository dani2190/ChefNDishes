using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefNDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId { get; set; }
        [Required(ErrorMessage = "Chef's First Name is required")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Chef's Last Name is required")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "DOB is required")]
        [Display(Name = "Date of Birth:")]
        public DateTime DateofBirth{get;set;}
        public List<Dish> CreatedDishes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}