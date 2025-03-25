using PPB.Models.Constants;

namespace PPB.Models
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
