using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using weddingPlanner.Models;

namespace weddingPlanner.Controllers
{
    public class HomeController : Controller   
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        
        // Routes: Login and Registration
        [HttpGet("")]   
        public IActionResult LoginReg()
        {
            return View();
        }

        [HttpPost("register/submit")]
        public IActionResult RegisterSubmit(User user)
        {
            if(ModelState.IsValid)
            {
                if(_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("LoginReg", user);
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("LoginReg");
            }
            return View("LoginReg", user);
        }

        [HttpPost("login/submit")]   
        public IActionResult LoginSubmit(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.Email);
                if(userInDb == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("LoginReg", userSubmission);
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Password Hashing Failure");
                    return View("LoginReg", userSubmission);
                }
                HttpContext.Session.SetInt32("UserInSession", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("LoginReg", userSubmission);
        }


        // Routes: Dashboard
        [HttpGet("dashboard")]   
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserInSession") == null)
            {
                return RedirectToAction("LoginReg");
            }

            ViewBag.allWeddings = _context.Weddings
                .Include(wed => wed.Creator)
                .Include(wed => wed.Reservations)
                    .ThenInclude(rsvp => rsvp.User)
                .ToList();

            

            ViewBag.UserLoggedIn = HttpContext.Session.GetInt32("UserInSession");

            return View();
        }

        [HttpGet("rsvp/{WeddingId}")]   
        public IActionResult RSVP(int WeddingId)
        {
            Reservation newRes = new Reservation();
            newRes.WeddingId = WeddingId;
            newRes.UserId = (int)HttpContext.Session.GetInt32("UserInSession");
            _context.Add(newRes);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        // Routes: Plan Wedding
        [HttpGet("plan/wedding")]   
        public IActionResult PlanWedding()
        {
            return View();
        }

        [HttpPost("plan/wedding/submit")]   
        public IActionResult PlanWeddingSubmit(Wedding newWedding)
        {
            newWedding.UserId = (int)HttpContext.Session.GetInt32("UserInSession");
            if (newWedding.Date < DateTime.Now) 
            {
                ModelState.AddModelError("Date", "Date must be in the future!");
                    return View("PlanWedding", newWedding);
            }
            if (ModelState.IsValid)
            {
                _context.Add(newWedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("PlanWedding", newWedding);
        }



        // Routes: Logout
        [HttpGet("logout")]   
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginReg");
        }
    }
}