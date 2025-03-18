using AccountingAppV3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingAppV3.ViewModels
{
    class NewAccountPageViewModel
    {
        public async Task SaveAccountAsync(Account account)
        {
            using (var db = new BokforingContext())
            {
                db.Accounts.Add(account);
                await db.SaveChangesAsync();
            }
        }
        public async Task UpdateAccountAsync(Account account)
        {
            using (var db = new BokforingContext())
            {
                db.Accounts.Update(account);
                await db.SaveChangesAsync();
            }
        }
    }
}
