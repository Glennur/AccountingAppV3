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
    class AllSupplierPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        private ObservableCollection<Models.Supplier> _suppliers;
        public ObservableCollection<Models.Supplier> Suppliers
        {
            get
            {
                return _suppliers;
            }
            set
            {
                _suppliers = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Suppliers"));
        }

        public AllSupplierPageViewModel()
        {
            Suppliers = new ObservableCollection<Models.Supplier>();
            LoadSuppliersAsync();
        }
        private async void LoadSuppliersAsync()
        {
            var data = await GetSuppliersFromDbAsync();
            foreach(var supplier in data)
            {
                Suppliers.Add(supplier);
            }
        }
        private async Task<List<Models.Supplier>> GetSuppliersFromDbAsync()
        {
            using (var db = new BokforingContext())
            {
                return await db.Suppliers.ToListAsync();
            }
        }
    }
    
}
