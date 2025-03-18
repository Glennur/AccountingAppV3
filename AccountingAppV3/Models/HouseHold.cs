using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class HouseHold
    {
        public int Id { get; set; }
        public string AddressName { get; set; }

        public virtual ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
