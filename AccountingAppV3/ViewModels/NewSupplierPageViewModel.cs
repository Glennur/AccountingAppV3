using AccountingAppV3.Models;

namespace AccountingAppV3.ViewModels
{
    class NewSupplierPageViewModel
    {
        public async Task SaveSupplierAsync(Supplier supplier)
        {
            using (var db = new BokforingContext())
            {
                db.Suppliers.Add(supplier);
                db.SaveChangesAsync();
            }
        }
        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            using (var db = new BokforingContext())
            {
                db.Suppliers.Update(supplier);
                db.SaveChangesAsync();
            }
        }
    }
}
