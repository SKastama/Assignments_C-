using Microsoft.AspNetCore.Mvc;
using viewModelFun.Models;
using System.Collections.Generic;
namespace viewModelFun.Controllers
{
    public class HomeController : Controller   
    {
        [HttpGet("")]   
        public IActionResult Names()
        {
            string[] names = new string[]
            {
                "Sally",
                "Billy",
                "Joey",
                "Moose"
            };
            return View(names);
        }
        [HttpGet("integers")]   
        public IActionResult Integers()
        {
            int[] integers = new int[]
            {
                1, 2, 3, 10, 43, 5
            };
            return View(integers);
        }

        [HttpGet("users")]   
        public IActionResult Users()
        {
            User user1 = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };

            User user2 = new User()
            {
                FirstName = "Sarah",
                LastName = ""
            };

            User user3 = new User()
            {
                FirstName = "Jerry",
                LastName = ""
            };

            List<User> viewModel = new List<User>()
            {
                user1, user2, user3
            };
            return View(viewModel);
        }

        [HttpGet("users/one")]   
        public IActionResult OneUser()
        {
            User user1 = new User()
            {
                FirstName = "Moose",
                LastName = "Phillips"
            };
            
            return View(user1);
        }
    }
}