namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Guest
    {
        public Guest()
        {
            this.Bills = new HashSet<Bill>();
            this.Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string EGN { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string CardNumber { get; set; }

        public int GuestContactId { get; set; }

        public GuestContact GuestContact { get; set; }

        public ICollection<Bill> Bills { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

        public ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
