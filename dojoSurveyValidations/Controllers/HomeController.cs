using Microsoft.AspNetCore.Mvc;
using dojoSurveyValidations.Models;
using System.Collections.Generic;
namespace dojoSurveyValidations.Controllers
{
    public class HomeController : Controller   
    {
        [HttpGet("")]   
        public ViewResult Form()
        {
            return View();
        }

        [HttpPost("/submit")]   
        public ViewResult Submitted(User user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }
            else 
            {
                return View("Form");
            }
        }
    }
}