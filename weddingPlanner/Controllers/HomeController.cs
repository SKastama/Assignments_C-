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

            List<Wedding> allWeddings = _context.Weddings
                .Include(wed => wed.Creator)
                .Include(wed => wed.Reservations)
                    .ThenInclude(rsvp => rsvp.User)
                .ToList();

            ViewBag.UserLoggedIn = HttpContext.Session.GetInt32("UserInSession");

            return View(allWeddings);
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

        [HttpGet("unrsvp/{ReservationId}")]   
        public IActionResult unRSVP(int ReservationId)
        {
            Reservation RetrievedRSVP = _context.Reservations
                .SingleOrDefault(res => res.ReservationId == ReservationId);
            _context.Reservations.Remove(RetrievedRSVP);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("delete/{WeddingId}")]   
        public IActionResult Delete(int WeddingId)
        {
            Wedding RetrievedWedding = _context.Weddings
                .SingleOrDefault(wed => wed.WeddingId == WeddingId);
            _context.Weddings.Remove(RetrievedWedding);
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

        // Routes: One Wedding
        [HttpGet("wedding/{WeddingId}")]   
        public IActionResult ViewOne(int WeddingId)
        {
            Wedding oneWedding = _context.Weddings
                .Include(wed => wed.Creator)
                .Include(wed => wed.Reservations)
                    .ThenInclude(rsvp => rsvp.User)
                .SingleOrDefault(wed => wed.WeddingId == WeddingId);

            return View(oneWedding);
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