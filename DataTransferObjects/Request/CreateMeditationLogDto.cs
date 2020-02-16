using System;

namespace HypertropeCore.DataTransferObjects.Request
{
    public class CreateMeditationLogDto
    {
        public DateTime? Created { get; set; } = null;
        public string Notes { get; set; }
        public int Silence { get; set; }
        public int Willingness { get; set; }
    }
}