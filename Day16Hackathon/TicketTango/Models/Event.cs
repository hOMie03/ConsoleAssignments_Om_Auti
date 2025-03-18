﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TicketTango.Models
{
    public class Event
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required, NotNull]
        public string Name { get; set; }

        [Required, NotNull]
        public string Location { get; set; }

        [Required, NotNull]
        public DateTime DateOfEvent { get; set; }

        [Required, NotNull]
        public int AvailableSeats { get; set; }

        [AllowNull]
        public decimal TicketPrice { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
