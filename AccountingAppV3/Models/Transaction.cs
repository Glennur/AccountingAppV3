using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class Transaction
    {
        public int Id { get; set; } //Unikt id for transaktion
        public string? VerificationNr { get; set; } //Verifikationsnummer
        public DateTime Date { get; set; } //Datum
        public decimal Amount { get; set; } //Summa
        public int DebitAccountId { get; set; } //Debit
        public int CreditAccountId { get; set; } //Kredit
        public int? SupplierId { get; set; }
        public int? HouseHoldId { get; set; }
        public string? Description { get; set; } //Beskrivning
        public int Year { get; set; }

        public virtual YearStatus YearStatus { get; set; } = null!;
        public virtual Account DebitAccount { get; set; } = null;
        public virtual Account CreditAccount { get; set; } = null;
        public virtual Supplier? Supplier { get; set; }
        public virtual HouseHold? HouseHold { get; set; } = null;
    }
}
