using System.Drawing;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    public class WorkoutController : Controller
    {
        public WorkoutController()
        {
            
        }

        [HttpPost(ApiRoutes.Workouts.Create)]
        public IActionResult CreateWorkout()
        {
            return new JsonResult(new {Route = "CreateWorkout"});
        }

        [HttpGet(ApiRoutes.Workouts.Create)]
        public IActionResult ShowWorkouts()
        {
            return new JsonResult(new {Route = "ShowWorkouts"});
        }
    }
}