using System.Collections.Generic;
using HypertropeCore.Domain;

namespace HypertropeCore.DataTransferObjects.Request
{
    public class WorkoutCreateRequest
    {
        public List<Set> Sets { get; set; }
        public string Notes { get; set; }
    }
}