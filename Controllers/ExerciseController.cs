using System;
using System.Linq;
using System.Threading.Tasks;
using HypertropeCore.Context;
using HypertropeCore.Contracts.V1.Request;
using HypertropeCore.Contracts.V1.Response;
using HypertropeCore.Domain;
using HypertropeCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HypertropeCore.Controllers
{
    [Authorize]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly HypertropeCoreContext _context;

        public ExerciseController(HypertropeCoreContext context)
        {
            _context = context;
        }

        [HttpPost(ApiRoutes.Exercises.Create)]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExerciseRequest request)
        {
            var newExercise = new Exercise
            {
                ExerciseId = Guid.NewGuid(),
                Name = request.Name,
                Abbreviation = request.Abbrev
            };

            await _context.Exercises.AddAsync(newExercise);
            await _context.SaveChangesAsync();
            
            return new JsonResult(new Response<ExerciseCreatedResponse>(new ExerciseCreatedResponse{ExerciseId = newExercise.ExerciseId}));
        }
        
        [HttpGet(ApiRoutes.Exercises.ShowAll)]
        public IActionResult ExerciseList()
        {
            var allExercises = _context.Exercises.ToList();
            return new JsonResult(new {Exercises = allExercises});
        }
    }
}