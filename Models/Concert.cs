﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_App.Models
{
    public class Concert
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SingerName { get; set; }
        public string? Supporter { get; set; }
        public double? Price { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
        [ValidateNever]
        public string? PhotoUrl { get; set; }
    }
}
