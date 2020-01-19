using System.Collections.Generic;
using HypertropeCore.Models;

namespace HypertropeCore.Contracts.V1.Response
{
    public class ExerciseGroup
    {
        public string Name { get; set; }
        public List<SetResponse> Sets { get; set; } = new List<SetResponse>();
    }
}