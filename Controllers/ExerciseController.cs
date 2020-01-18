using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [ApiController]
    public class ExerciseController : Controller
    {
        [HttpGet(ApiRoutes.Exercises.ShowAll)]
        public IActionResult ExerciseList()
        {
            return new JsonResult(new {Exercises = "here is a list"});
        }
    }
}