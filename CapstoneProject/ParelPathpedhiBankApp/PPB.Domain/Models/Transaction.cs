using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models.Constants;

namespace PPB.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public Account Account { get; set; }

        public TransactionTypes Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
