using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using cExam.Models;

namespace cExam.Controllers
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
                    return View("LoginReg");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                user.Password = Hasher.HashPassword(user, user.Password);
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction("LoginReg");
            }
            return View("LoginReg");
        }

        [HttpPost("login/submit")]   
        public IActionResult LoginSubmit(LoginUser userSubmission)
        {
            if(ModelState.IsValid)
            {
                var userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("LoginReg");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
                if(result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Password Hashing Failure");
                    return View("LoginReg");
                }
                HttpContext.Session.SetInt32("UserInSession", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            return View("LoginReg");
        }

        // Routes: Dashboard
        [HttpGet("dashboard")]   
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetInt32("UserInSession") == null)
            {
                return RedirectToAction("LoginReg");
            }
            ViewBag.UserLoggedIn = HttpContext.Session.GetInt32("UserInSession");
            return View();
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