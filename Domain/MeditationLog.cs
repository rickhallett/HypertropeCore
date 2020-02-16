using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypertropeCore.Domain
{
    public class MeditationLog
    {
        [Key]
        [Column("MeditationLogId")]
        public Guid MeditationLogId { get; set; }
        
        public DateTime Created { get; set; }
        
        [Required(ErrorMessage = "Notes are a required field. This is the entire point.")]
        public string Notes { get; set; }
        
        [Required(ErrorMessage = "Anxiety is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Silence { get; set; }
        
        [Required(ErrorMessage = "Willingness is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Willingness { get; set; }
    }
}