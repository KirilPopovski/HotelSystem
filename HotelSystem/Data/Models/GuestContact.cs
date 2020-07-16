namespace HotelSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class GuestContact
    {
        public GuestContact()
        {
            this.Guests = new HashSet<Guest>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(12)]
        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Guest> Guests { get; set; }
    }
}
