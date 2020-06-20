using System;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.RequestModel
{
    public class ChangePerformanceDate
    {
        [Required]
        public DateTime PerformanceDate { get; set; }
    }
}