using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HypertropeCore.Models;
using Microsoft.AspNetCore.Identity;

namespace HypertropeCore.Domain
{
    public class Workout
    {
        public Guid WorkoutId { get; set; }
        
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public List<Set> Sets { get; set; }
        public int TotalVolume { get; set; }
        public double AverageOneRm { get; set; }
        public string Notes { get; set; }
    }
}