using PPB.Models.Constants;

namespace PPB.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public long AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public AccountTypes AccountType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
