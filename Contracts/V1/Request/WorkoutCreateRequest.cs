using System.Collections.Generic;
using HypertropeCore.Models;

namespace HypertropeCore.Contracts.V1.Request
{
    public class WorkoutCreateRequest
    {
        public List<Set> Sets { get; set; }
    }
}