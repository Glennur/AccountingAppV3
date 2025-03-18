using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.ViewModels
{
    class HouseHoldDetailViewModel
    {
        public Models.HouseHold HouseHold { get; set; }
        public List<Models.Member> Members { get; set; }

        public HouseHoldDetailViewModel(Models.HouseHold houseHold, List<Models.Member> members)
        {
            HouseHold = houseHold;
            Members = members;
        }
    }
}
