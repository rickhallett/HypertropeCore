using System.Collections.Generic;

namespace HypertropeCore.DataTransferObjects.Response
{
    public class ExerciseGroup
    {
        public string Name { get; set; }
        public List<SetResponse> Sets { get; set; } = new List<SetResponse>();
    }
}