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
    class AllAccountPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Models.Account> _accounts;
        public ObservableCollection<Models.Account> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Accounts"));
        }
        public AllAccountPageViewModel()
        {
            Accounts = new ObservableCollection<Models.Account>();

            LoadAccountsAsync();
        }
        private async void LoadAccountsAsync()
        {
            var data = await GetAccountsFromDbAsync();
            foreach(var account in data)
            {
                Accounts.Add(account);
            }
        }
        private async Task<List<Models.Account>> GetAccountsFromDbAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.Accounts.OrderBy(a => a.AccountNumber).ToListAsync();
            }
        }
    }
}
