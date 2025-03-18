using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class YearStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  // Viktigt för att inaktivera IDENTITY
        public int Year { get; set; }
        public decimal CashAmount { get; set; }
        public decimal BankAmount { get; set; }
        public bool IsClosed { get; set; }
        public DateOnly StartDate { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
