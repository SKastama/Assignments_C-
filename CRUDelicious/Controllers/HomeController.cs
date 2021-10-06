using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        

        // Routes
        [HttpGet("")]   
        public IActionResult DashBoard()
        {
            ViewBag.AllDishes = _context.Users.ToList();
            
            return View();
        }

        [HttpGet("new")]   
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("new/submit")]   
        public IActionResult Submitted(User newUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newUser);
                _context.SaveChanges();
                return RedirectToAction("DashBoard");
            }
            return View("Add", newUser);
        }

        [HttpGet("{UserId}")]   
        public IActionResult ViewOne(int UserId)
        {
            ViewBag.RetrievedUser = _context.Users
                .SingleOrDefault(user => user.UserId == UserId);
            return View();
        }

        [HttpGet("delete/{UserId}")]   
        public IActionResult Delete(int UserId)
        {
            User RetrievedUser = _context.Users
                .SingleOrDefault(user => user.UserId == UserId);
            _context.Users.Remove(RetrievedUser);
            _context.SaveChanges();
            return RedirectToAction("DashBoard");
        }

        [HttpGet("edit/{UserId}")]   
        public IActionResult Edit(int UserId)
        {
            User RetrievedUser = _context.Users
                .SingleOrDefault(user => user.UserId == UserId);
            return View(RetrievedUser);
        }

        [HttpPost("edit/{UserId}/submit")]   
        public IActionResult Edited(int UserId, User newUser)
        {
            User RetrievedUser = _context.Users
                .SingleOrDefault(user => user.UserId == UserId);
            RetrievedUser.chefName= newUser.chefName;
            RetrievedUser.dishName= newUser.dishName;
            RetrievedUser.Calories= newUser.Calories;
            RetrievedUser.Taste= newUser.Taste;
            RetrievedUser.Description= newUser.Description;
            RetrievedUser.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("ViewOne");

        }

    }

}