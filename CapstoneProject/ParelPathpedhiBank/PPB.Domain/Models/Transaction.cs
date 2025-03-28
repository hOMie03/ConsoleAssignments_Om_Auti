using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models.Constants;

namespace PPB.Domain.Models
{
    public class Transaction
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int AccountID { get; set; }
        public Account Account { get; set; }

        [Required, NotNull]
        public TransactionTypes TType { get; set; }

        [Required, NotNull]
        public decimal Amount { get; set; }

        [Required, NotNull]
        public DateTime Date { get; set; }

        [AllowNull]
        public string Description { get; set; }
    }
}
