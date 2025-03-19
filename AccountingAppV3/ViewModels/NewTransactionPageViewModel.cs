using AccountingAppV3.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace AccountingAppV3.ViewModels
{
    class NewTransactionPageViewModel : INotifyPropertyChanged
    {
        public int CurrentYear { get; private set; }
        public async Task<bool> CheckIfYearExistsAsync()
        {
            using (var db = new BokforingContext())
            {
                var yearStatus = await db.yearStatuses
                    .Where(y => !y.IsClosed)
                    .OrderByDescending(y => y.Year)
                    .FirstOrDefaultAsync();
                if (yearStatus != null)
                {
                    CurrentYear = yearStatus.Year;
                    OnPropertyChanged(nameof(CurrentYear));
                    return true;
                }
                return false;
            }
        }
        private static NewTransactionPageViewModel _instance;
        public static NewTransactionPageViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NewTransactionPageViewModel();
                }
                return _instance;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<Models.Account> _accounts = new ObservableCollection<Account>();
        public ObservableCollection<Models.Account> Accounts
        {
            get
            {
                return _accounts;
            }
            set
            {
                _accounts = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }
        private ObservableCollection<Models.Supplier> _suppliers = new ObservableCollection<Supplier>();
        public ObservableCollection<Models.Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }
            set
            {
                _suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }
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

        private ObservableCollection<Selection> _selectionList = new();
        public ObservableCollection<Selection> SelectionList
        {
            get => _selectionList;
            set
            {
                _selectionList = value;
                OnPropertyChanged(nameof(SelectionList));
            }
        }

        private Models.Account _selectedDebitAccount;
        public Models.Account SelectedDebitAccount
        {
            get => _selectedDebitAccount;

            set
            {
                _selectedDebitAccount = value;
                OnPropertyChanged(nameof(SelectedDebitAccount));
            }
        }
        private Models.Account _selectedCreditAccount;
        public Models.Account SelectedCreditAccount
        {
            get => _selectedCreditAccount;

            set
            {
                _selectedCreditAccount = value;
                OnPropertyChanged(nameof(SelectedCreditAccount));
            }
        }
        public List<string> SupplierOrHouseHold { get; } = new List<string>
        {
            "Medlem",
            "Leverantör"
        };


        private string _selectedSupplierOrHouseHold;
        public string SelectedSupplierOrHouseHold
        {
            get => _selectedSupplierOrHouseHold;
            set
            {

                _selectedSupplierOrHouseHold = value;
                OnPropertyChanged(nameof(SelectedSupplierOrHouseHold));

                UpdateSelectionList();


            }
        }
        private int _selectedSupOrHouse;
        public int SelectedSupOrHouse
        {
            get => _selectedSupOrHouse;
            set
            {
                _selectedSupOrHouse = value;
                OnPropertyChanged(nameof(SelectedSupOrHouse));
            }
        }

        private object _selectedAlternative;
        public object SelectedAlternative
        {
            get => _selectedAlternative;
            set
            {
                _selectedAlternative = value;
                if (_selectedAlternative is Selection selection)
                {
                    if (selection.Data is Models.Supplier supplier)
                    {
                        SelectedSupOrHouse = supplier.Id;
                    }
                    else if (selection.Data is Models.HouseHold houseHold)
                    {
                        SelectedSupOrHouse = houseHold.Id;
                    }
                    else
                    {
                        SelectedSupOrHouse = 0;
                    }
                }
                else
                {
                    SelectedSupOrHouse = 0;
                }
                OnPropertyChanged(nameof(SelectedAlternative));
            }
        }
        public class Selection
        {
            public string DisplayText { get; set; }
            public object Data { get; set; }
        }
        private void UpdateSelectionList()
        {
            SelectionList.Clear();
            if (SelectedSupplierOrHouseHold == "Medlem")
            {
                foreach (var houseHold in HouseHolds)
                {
                    SelectionList.Add(new Selection
                    {

                        DisplayText = "Vallsundsvägen " + houseHold.AddressName,
                        Data = houseHold
                    });
                    SelectedSupOrHouse = 0;


                }
            }
            else if (SelectedSupplierOrHouseHold == "Leverantör")
            {
                foreach (var supplier in Suppliers)
                {
                    SelectionList.Add(new Selection
                    {
                        DisplayText = supplier.SupplierAccountNumber + " - " + supplier.SupplierName,
                        Data = supplier
                    });

                }
                SelectedSupOrHouse = 0;
            }
        }



        private Models.Transaction _newTransaction;
        public Models.Transaction NewTransaction
        {
            get => _newTransaction;
            set
            {
                _newTransaction = value;
                OnPropertyChanged(nameof(NewTransaction));
            }
        }
        public string ErrorMessageDate { get; private set; }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (value.Year == CurrentYear)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                    ErrorMessageDate = "";
                    OnPropertyChanged(nameof(ErrorMessageDate));
                }
                else
                {
                    ErrorMessageDate = "Datumet du angivet är felaktigt";
                    OnPropertyChanged(nameof(ErrorMessageDate));
                }
            }
        }
        public string ErrorMessageVerification { get; set; }

        private string _verificationNumber;
        public string VerificationNumber
        {
            get => _verificationNumber;
            set
            {
                _verificationNumber = value;
                if (VerificationCheck(_verificationNumber))
                {
                    ErrorMessageVerification = "";
                    OnPropertyChanged(nameof(VerificationNumber));
                    OnPropertyChanged(nameof(ErrorMessageVerification));
                }
                else
                {
                    ErrorMessageVerification = "Fel format på verifikationsnummer. 0000-000";
                    OnPropertyChanged(nameof(VerificationNumber));
                    OnPropertyChanged(nameof(ErrorMessageVerification));
                }

            }
        }
        private bool VerificationCheck(string verificationNumber)
        {
            if (string.IsNullOrEmpty(verificationNumber))
            {
                return false;
            }
            string regexPattern = $@"{CurrentYear}" + @"-\d{3}$";
            return Regex.IsMatch(VerificationNumber, regexPattern);
        }

        public string ErrorMessageAmount { get; set; }

        private string _amount;
        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
                if (decimal.TryParse(_amount.Trim(), out decimal amountResult))
                {
                    if (amountResult >= 0)
                    {
                        ErrorMessageAmount = "";
                        OnPropertyChanged(nameof(ErrorMessageAmount));
                        OnPropertyChanged(nameof(Amount));
                    }
                    else
                    {
                        ErrorMessageAmount = "Enbart positiva värden tillåtna";
                        OnPropertyChanged(nameof(ErrorMessageAmount));
                        OnPropertyChanged(nameof(Amount));
                    }
                }
                else
                {
                    ErrorMessageAmount = "Felaktigt inmatat belopp";
                    OnPropertyChanged(nameof(ErrorMessageAmount));
                }
            }
        }
        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        public NewTransactionPageViewModel()
        {
            LoadAccountsAsync();
            LoadSuppliersAsync();
            LoadHouseHoldsAsync();
            NewTransaction = new Models.Transaction();
        }

        private async void LoadAccountsAsync()
        {
            var data = await GetAccountsAsync();
            foreach (var account in data)
            {
                Accounts.Add(account);
            }
        }

        private async Task<List<Models.Account>> GetAccountsAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.Accounts.OrderBy(a => a.AccountNumber).ToListAsync();
            }
        }
        private async void LoadSuppliersAsync()
        {
            var data = await GetSupplierAsync();
            Suppliers.Clear();
            foreach (var supplier in data)
            {
                Suppliers.Add(supplier);
            }
        }
        private async Task<List<Models.Supplier>> GetSupplierAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.Suppliers.ToListAsync();
            }
        }
        private async void LoadHouseHoldsAsync()
        {
            var data = await GetHouseHoldAsync();
            HouseHolds.Clear();
            foreach (var houseHold in data)
            {
                HouseHolds.Add(houseHold);
            }
        }
        private async Task<List<Models.HouseHold>> GetHouseHoldAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.HouseHolds.ToListAsync();
            }
        }


        public string ErrorMessage { get; set; }
        private void SetErrorMessage(string message)
        {
            ErrorMessage = message;
            OnPropertyChanged(nameof(ErrorMessage));
        }
        public async Task CreateNewTransactionAsync()
        {
            if (SelectedDate.Year != CurrentYear)
            {
                SetErrorMessage("Fel: Datumet måste vara inom det aktuella året.");

                return;
            }
            if (!VerificationCheck(VerificationNumber))
            {
                SetErrorMessage("Fel: Verifikationsnummer är inte i rätt format.");

                return;
            }
            if (!decimal.TryParse(Amount, out decimal parsedAmount))
            {
                SetErrorMessage("Fel: Amount är inte ett giltigt decimaltal.");

                return;
            }
            if (SelectedDebitAccount == null || SelectedCreditAccount == null)
            {
                SetErrorMessage("Fel: Debit- eller CreditAccount måste väljas.");

                return;
            }
            if (SelectedSupOrHouse == 0)
            {
                SetErrorMessage("Fel: Hushåll eller leverantör måste väljas");
                return;
            }

            var newTransaction = new Models.Transaction()
            {
                VerificationNr = VerificationNumber,
                Date = SelectedDate,
                Amount = parsedAmount,
                DebitAccountId = SelectedDebitAccount.Id,
                CreditAccountId = SelectedCreditAccount.Id,
                Description = NewTransaction.Description,
                Year = CurrentYear
            };

            if (SelectedSupplierOrHouseHold == "Medlem")
            {
                newTransaction.HouseHoldId = SelectedSupOrHouse;
            }
            else if (SelectedSupplierOrHouseHold == "Leverantör")
            {
                newTransaction.SupplierId = SelectedSupOrHouse;
            }
            await UpdateAccountBalanceAsync(SelectedDebitAccount, parsedAmount); // Minska saldot för debetkontot
            await UpdateAccountBalanceAsync(SelectedCreditAccount, -parsedAmount); // Öka saldot för kreditkontot
            using (var db = new BokforingContext())
            {
                db.Transactions.Add(newTransaction);
                await db.SaveChangesAsync();
                SetErrorMessage($"{VerificationNumber} - {NewTransaction.Description} är bokförd");
            }
        }

        private async Task UpdateAccountBalanceAsync(Account account, decimal amountChange)
        {
            account.Balance += amountChange;
            using (var db = new BokforingContext())
            {
                db.Accounts.Update(account);
                await db.SaveChangesAsync();               
            }
        }

        protected void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }

    }
}
