using AccountingAppV3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.ViewModels
{
    class FirstTransactionPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Models.YearStatus _newYearStatus;
        public Models.YearStatus NewYearStatus
        {
            get => _newYearStatus;
            set
            {
                _newYearStatus = value;
                OnPropertyChanged(nameof(NewYearStatus));
            }
        }
        public FirstTransactionPageViewModel()
        {
            NewYearStatus = new Models.YearStatus();
        }        

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
                NewYearStatus.StartDate = DateOnly.FromDateTime(value);
            }
        }
        private decimal _cashAmount;
        public decimal CashAmount
        {
            get => NewYearStatus.CashAmount;
            set
            {
           if (decimal.TryParse(value.ToString(), out var result))
                {
                    if (_cashAmount != result)
                    {
                        _cashAmount = result;
                        NewYearStatus.CashAmount = result;
                        OnPropertyChanged(nameof(CashAmount));
                    }
                }
                else
                {
                    //ErrorMessage = "Felaktigt belopp, vänligen ange ett giltigt tal.";
                    
                }
            }
        }
        private decimal _bankGiroAmount;
        public decimal BankGiroAmount
        {
            get => _bankGiroAmount;
            set
            {                
                if (decimal.TryParse(value.ToString(), out var result))
                {
                    if (_bankGiroAmount != result)
                    {
                        _bankGiroAmount = result;
                        NewYearStatus.BankAmount = result;
                        OnPropertyChanged(nameof(BankGiroAmount));
                    }
                }
                else
                {
                    //ErrorMessage = "Felaktigt belopp, vänligen ange ett giltigt tal.";
                    
                    // Felmeddelande                   
                }
            }
        }

        protected void OnPropertyChanged(string data)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(data));
        }







        public async Task CreateFirstTransactionAsync()
        {
            using (var db = new BokforingContext())
            {
                var newEntry = new YearStatus
                {
                    Year = NewYearStatus.StartDate.Year,
                    CashAmount = NewYearStatus.CashAmount,
                    BankAmount = NewYearStatus.BankAmount,
                    StartDate = NewYearStatus.StartDate,
                    IsClosed = false
                };
                db.yearStatuses.Add(newEntry);  // Lägg till posten i databasen
                await db.SaveChangesAsync();
            }
        }
    }
}
