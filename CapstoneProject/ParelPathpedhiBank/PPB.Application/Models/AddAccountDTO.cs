using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPB.Domain.Models.Constants;

namespace PPB.Application.Models
{
    public class AddAccountDTO
    {
        public string UserID { get; set; }
        public decimal Balance { get; set; }
        public AccountTypes AccountType { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
