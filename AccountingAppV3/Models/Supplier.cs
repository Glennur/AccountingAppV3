using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class Supplier
    {
        public int Id { get; set; } // Unikt ID
        public string SupplierName { get; set; } // Namn
        public string? SupplierAccountNumber { get; set; } // Konto att betala in till
        public string? Description { get; set; } // Beskrivning    
    }
}
