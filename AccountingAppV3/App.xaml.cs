using AccountingAppV3.Models;
using Microsoft.EntityFrameworkCore;


namespace AccountingAppV3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
