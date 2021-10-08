using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using chefDishes.Models;

namespace chefDishes.Controllers
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        // Routes: Chefs
        [HttpGet("")]   
        public IActionResult ViewChefs()
        {
            List<Chef> allChefs = _context.Chefs
                .Include(chef => chef.CreatedDishes)
                .ToList();
            return View(allChefs);
        }

        [HttpGet("chefs/new")]   
        public IActionResult AddChef()
        {
            return View();
        }

        [HttpPost("chefs/new/submit")]   
        public IActionResult SubmitChef(Chef newChef)
        {
            var age = DateTime.Now.Year - newChef.Birthdate.Year;
            if (age < 18) {
                ModelState.AddModelError("Birthdate", "Chef's must be 18 years or older!");
                    return View("AddChef", newChef);
            }
            if (ModelState.IsValid)
            {
                _context.Add(newChef);
                _context.SaveChanges();
                return RedirectToAction("ViewChefs");
            }
            return View("AddChef", newChef);
        }


        // Routes: Dishes
        [HttpGet("dishes")]   
        public IActionResult ViewDishes()
        {
            List<Dish> allDishes = _context.Dishes
                .Include(dish => dish.Creator)
                .ToList();
            return View(allDishes);
        }

        [HttpGet("dishes/new")]   
        public IActionResult AddDish()
        {
            ViewBag.allChefs = _context.Chefs.ToList();
            return View();
        }

        [HttpPost("dishes/new/submit")]   
        public IActionResult SubmitDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("ViewDishes");
            }
            return View("AddDish", newDish);
        }
    }
}