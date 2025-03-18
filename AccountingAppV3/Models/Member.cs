using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HouseHoldId { get; set; }
        public string? Email { get; set; }
        public string? PhoneMobile { get; set; }
        public string? PhoneHome { get; set; }
        public DateOnly? DateOfBirth { get; set; }

        public HouseHold houseHold { get; set; }
    }
}
