using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Collections.Generic;
using theWall.Models;

namespace theWall.Controllers
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
                return RedirectToAction("Wall");
            }
            return View("LoginReg");
        }

        // Routes: Wall
        [HttpGet("wall")]   
        public IActionResult Wall()
        {
            if (HttpContext.Session.GetInt32("UserInSession") == null)
            {
                return RedirectToAction("LoginReg");
            }
            ViewBag.allMessages = _context.Messages
                .Include(mes => mes.Creator)
                .Include(mes => mes.CreatedComments)
                .ToList();

            ViewBag.UserLoggedIn = HttpContext.Session.GetInt32("UserInSession");
            
            return View();
        }

        [HttpPost("wall/message/submit")]   
        public IActionResult MessageSubmit(Message newMes)
        {
            newMes.UserId = (int)HttpContext.Session.GetInt32("UserInSession");
            if (ModelState.IsValid)
            {
                _context.Add(newMes);
                _context.SaveChanges();
                return RedirectToAction("Wall");
            }
            return View("Wall", newMes);
        }

        [HttpPost("wall/comment/submit")]   
        public IActionResult CommentSubmit(Comment newCom)
        {
            newCom.UserId = (int)HttpContext.Session.GetInt32("UserInSession");
            if (ModelState.IsValid)
            {
                _context.Add(newCom);
                _context.SaveChanges();
                return RedirectToAction("Wall");
            }
            return View("Wall", newCom);
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