using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypertropeCore.Domain
{
    public class VitalitySnapshot
    {
        [Key]
        [Column("VitalitySnapshotId")]
        public Guid Id { get; set; }
        
        public DateTime Created { get; set; }
        
        [Required(ErrorMessage = "Mood is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Mood { get; set; }
        
        [Required(ErrorMessage = "Energy is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Energy { get; set; }
        
        [Required(ErrorMessage = "Focus is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Focus { get; set; }
        
        [Required(ErrorMessage = "Anxiety is a required field, min = 0, max = 10")]
        [Range(0, 10)]
        public int Anxiety { get; set; }
        
        public bool Fasted { get; set; }
    }
}