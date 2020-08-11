using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Controllers
{
    public class HomeController : Controller
    {
        private const string V = "dishes";
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext =context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Chef> ChefwithDishes = dbContext.Chefs
            .Include(Chef => Chef.CreatedDishes)
            .ToList();
            return View(ChefwithDishes);
        }
        [Route("new")]
        [HttpGet]
        public IActionResult NewChefView()
        {
            return View("NewChef");
        }
        [Route ("NewChef")]
        [HttpPost]
        public IActionResult NewChef(Chef newchef)
        {
            if(!ModelState.IsValid)
            {
                return View("NewChef");
            }
            else
            {
                DateTime now = DateTime.Today;
                if(DateTime.Compare(now,newchef.DateofBirth)< 0)
                {
                    ModelState.AddModelError("DateOfBirth", "DOB must earlier then current date");
                    return View("NewChef");
                }
                else
                {
                    dbContext.Chefs.Add(newchef);
                    dbContext.SaveChanges();
                    return Redirect("/");
                }
            }
        }
            [Route("dishes")]
            [HttpGet]
        public IActionResult Dishes()
        {
            List<Dish> DisheswithChef = dbContext.Dishes
            .Include(dish => dish.Creator)
            .ToList();
            return View(DisheswithChef);
        }

        

        [Route("dishes/new")]
        [HttpGet]
        public IActionResult NewDishView()
        {
            List<Chef> allChef = dbContext.Chefs.ToList();
            NewDish newdish =  new NewDish();
            newdish.allchefs = allChef;
            return View("NewDish",newdish);
        }

        [Route("NewDish")]
        [HttpPost]
        public IActionResult NewDish(NewDish newDish)
        {
            if (!ModelState.IsValid)
            {
                List<Chef> allChef =dbContext.Chefs.ToList();
                NewDish newdish = new NewDish();
                newdish.allchefs = allChef;
                return View("NewDish", newdish);
            }
            else
            {
                Dish newdish = new Dish();
                newdish.DishName = newDish.DishName;
                        newdish.ChefId = newDish.ChefId;
                        newdish.Description = newDish.Description;
                        newdish.Calories = newDish.Calories;
                        newdish.Tastiness = newDish.Tastiness;
                        dbContext.Dishes.Add(newdish);
                        dbContext.SaveChanges();
                        return Redirect("dishes");
            }
        }
        



        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
}
}


