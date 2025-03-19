using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using TicketTango.Models;

namespace TicketTango.ViewModels
{
    public class BookingViewModel
    {
        [Required, NotNull]
        public int UserID { get; set; }

        [Required, NotNull]
        public int EventID { get; set; }
        
        [Required, NotNull]
        public int Quantity { get; set; }
        
        [Required, NotNull]
        public decimal TotalCost { get; set; }
    }

}
