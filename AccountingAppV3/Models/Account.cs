using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class Account
    {
        public int Id { get; set; } // Unikt ID för kontot
        public int AccountNumber { get; set; } // Unikt kontonummer som är standard inom bokföring (4 siffror)
        public string AccountName { get; set; } // Namn på kontot        
        public decimal Balance { get; set; } // Aktuellt saldo
        public string AccountDescription { get; set; } // Beskriving av kontot

        public virtual ICollection<Transaction> DebitTransactions { get; set; } = new List<Transaction>();
        public virtual ICollection<Transaction> CreditTransactions { get; set; } = new List<Transaction>();
    }
}
