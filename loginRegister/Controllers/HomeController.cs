using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using loginRegister.Models;

namespace loginRegister.Controllers
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
        public IActionResult Register()
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
                    return View("Register", user);
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Register", user);
        }
        
        [HttpGet("login")]   
        public IActionResult Login()
        {
            return View();
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
                    return View("Login", userSubmission);
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.Password);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Password Hashing Failure");
                    return View("Login", userSubmission);
                }
                HttpContext.Session.SetInt32("UserInSession", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("Login", userSubmission);
        }

        [HttpGet("success")]   
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserInSession") == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet("logout")]   
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}