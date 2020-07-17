using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Data.Models
{
    public class Feedback
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Content { get; set; }

        [Required]
        public float Score { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
