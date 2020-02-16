using System;

namespace HypertropeCore.DataTransferObjects.Response
{
    public class MeditationLogResponseDto
    {
        public Guid MeditationLogId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public string Notes { get; set; }
        public int Silence { get; set; }
        public int Willingness { get; set; }
    }
}