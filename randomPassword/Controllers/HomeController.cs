using Microsoft.AspNetCore.Mvc;
using randomPassword.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace randomPassword.Controllers
{
    public class HomeController : Controller   
    {
        [HttpGet("")]   
        public ViewResult Index()
        {
            // HttpContext.Session.SetInt32("Count", (int)password.count);
            ViewBag.Count = HttpContext.Session.GetInt32("Count");
            ViewBag.Password = HttpContext.Session.GetString("Password");
            return View();
        }

        [HttpPost("generate")]   
        public IActionResult Generate()
        {
            Random rand = new Random();
            string passwordString = "";
            char[] charArray= 
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
                'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
                'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
                'Y', 'Z', '0', '1', '2', '3', '4', '5',
                '6', '7', '8', '9'
            };
            for (int val=0; val < 14; val++)
            {
                passwordString+= charArray[rand.Next(0, charArray.Length)];
            }
            HttpContext.Session.SetString("Password", passwordString);



            int? countTotal = HttpContext.Session.GetInt32("Count");
            if (countTotal == null) 
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("Count", Convert.ToInt32(HttpContext.Session.GetInt32("Count")) + 1);
            }
            return RedirectToAction("Index");
        }
    }

}