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
    public class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserID { get; set; }
        public User User { get; set; }

        [Required, NotNull]
        public long AccountNumber { get; set; }
        
        [Required, NotNull]
        public decimal Balance { get; set; }
        
        [Required, NotNull]
        public AccountTypes AccountType { get; set; }
        
        [Required, NotNull]
        public DateTime CreatedDate { get; set; }

        //public ICollection<Transaction> Transactions { get; set; }
    }
}
