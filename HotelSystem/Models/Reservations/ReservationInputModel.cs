namespace HotelSystem.Models.Reservations
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Mvc;

    public class ReservationInputModel
    {
        [BindProperty]
        [Required]
        public DateTime ChechIn { get; set; }

        [BindProperty]
        [Required]
        public DateTime CheckOut { get; set; }

        [BindProperty]
        [Required]
        public string HotelName { get; set; }

        [BindProperty]
        [Required]
        public int NumberOfPeople { get; set; }
    }
}
