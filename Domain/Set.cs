﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HypertropeCore.Domain
{
    public class Set
    {
        public Guid SetId { get; set; }
        
        public DateTime Created { get; set; }
        public string Exercise { get; set; }
        public int Weight { get; set; }
        public int Reps { get; set; }
        public int Volume { get; set; }
        public double OneRm { get; set; }
        
        [ForeignKey(nameof(Domain.Workout))]
        public Guid WorkoutId { get; set; }
    }
}