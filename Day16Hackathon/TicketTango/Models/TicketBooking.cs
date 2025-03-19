using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TicketTango.Models
{
    public class TicketBooking
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, NotNull]
        public int UserID { get; set; }
        public User User { get; set; }

        [Required, NotNull]
        public int EventID { get; set; }
        public Event Event { get; set; }

        [Required, NotNull]
        public int Quantity { get; set; }

        [Required, NotNull]
        public decimal TotalCost { get; set; }

        [Required, NotNull]
        public DateTime BookingDate { get; set; }

        [Required, NotNull]
        public bool Status { get; set; } // true = confirmed, false = canceled
    }
}
