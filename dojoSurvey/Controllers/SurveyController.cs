using Microsoft.AspNetCore.Mvc;
namespace dojoSurvey.Controllers     //be sure to use your own project's namespace!
{
    public class SurveyController : Controller   //remember inheritance??
    {
        [HttpGet("")]   
        public ViewResult Index()
        {
            return View();
        }


        [HttpPost("method")]   
        public ViewResult NewSurvey(string name, string location, string language, string comment)
        {
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;
            return View("NewSurvey");
        }
    }
}