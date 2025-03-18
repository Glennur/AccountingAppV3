using AccountingAppV3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.ViewModels
{
    class HouseHoldPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Models.HouseHold> _houseHolds;
        public ObservableCollection<Models.HouseHold> HouseHolds
        {
            get
            {
                return _houseHolds;
            }
            set
            {
                _houseHolds = value;
                OnPropertyChanged();
            }
        }
        
        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HouseHolds"));
        }

        public HouseHoldPageViewModel()
        {
            HouseHolds = new ObservableCollection<Models.HouseHold>();

            LoadHouseHoldsAsync();
        }
        private async void LoadHouseHoldsAsync()
        {
            var data = await GetHouseHoldsFromDbAsync();
            foreach (var houseHold in data)
            {
                HouseHolds.Add(houseHold);
            }
        }
        


        private async Task<List<Models.HouseHold>> GetHouseHoldsFromDbAsync()
        {
            using (var db = new BokforingContext())
            {                
                return await db.HouseHolds.ToListAsync();
            }
        }

        
    }
    
}
