using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSystem.Statistics.Models.Feedback
{
    public class FeedbackInputModel
    {
        [Required]
        public float Score { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
