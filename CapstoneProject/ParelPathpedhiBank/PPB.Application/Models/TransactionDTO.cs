using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models.Constants;

namespace PPB.Application.Models
{
    public class TransactionDTO
    {
        public int AccountID { get; set; }
        public TransactionTypes TType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; }
    }
}
