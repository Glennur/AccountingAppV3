using AccountingAppV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.ViewModels
{
    internal class NewMemberPageViewModel : INotifyPropertyChanged
    {
        private async void LoadHouseHoldAsync()
        {
            var data = await GetHouseHoldsFromDbAsync();
            foreach (var houseHold in data)
            {
                HouseHolds.Add(houseHold);
            }
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Models.HouseHold> _houseHolds = new ObservableCollection<HouseHold>();
        public ObservableCollection<Models.HouseHold> HouseHolds
        {
            get
            {
                return _houseHolds;
            }
            set 
            {
                _houseHolds = value;
                OnPropertyChanged(nameof(HouseHolds));
            }
        }
        private Models.HouseHold _selectedHouseHold;
        public Models.HouseHold SelectedHouseHold
        {
            get => _selectedHouseHold;
            set
            {
                if (_selectedHouseHold != value)
                {                    
                    _selectedHouseHold = value;
                    OnPropertyChanged(nameof(SelectedHouseHold));   
                }
            }
        }
        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
                NewMember.DateOfBirth = DateOnly.FromDateTime(value);  // Om du vill sätta DateOnly också
            }
        }



        private Models.Member _newMember;
        public Models.Member NewMember
        {
            get => _newMember;
            set
            {
                _newMember = value;
                OnPropertyChanged(nameof(NewMember));
            }
        }
       
        public NewMemberPageViewModel()
        {
            LoadHouseHoldAsync();
            NewMember = new Models.Member();
        }
        
        private async Task<List<Models.HouseHold>> GetHouseHoldsFromDbAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.HouseHolds.ToListAsync();
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task CreateNewMemberAsync()
        {
            var newMember = new Models.Member()
            {
                Name = NewMember.Name,
                HouseHoldId = SelectedHouseHold.Id,
                Email = NewMember.Email,
                PhoneMobile = NewMember.PhoneMobile,
                PhoneHome = NewMember.PhoneHome,
                DateOfBirth = NewMember.DateOfBirth

            };
            using (var db = new BokforingContext())
            {
                db.Members.Add(newMember);
                await db.SaveChangesAsync();
                ClearFields();

            }
        }
        private void ClearFields()
        {
            NewMember = new Models.Member(); // Återställ till ett nytt objekt
            DateOfBirth = DateTime.MinValue; // Eller ett annat standardvärde
            SelectedHouseHold = null;
        }


    }
}
