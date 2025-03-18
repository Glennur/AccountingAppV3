using AccountingAppV3.View;

namespace AccountingAppV3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;

            Routing.RegisterRoute("NewTransactionPage", typeof(View.NewTransactionPage));
            Routing.RegisterRoute("TransactionHistoryPage", typeof(View.TransactionHistoryPage));
            Routing.RegisterRoute("NewMemberPage", typeof(View.NewMemberPage));
            Routing.RegisterRoute("NewSupplierPage", typeof(View.NewSupplierPage));
            Routing.RegisterRoute("HouseHoldPage", typeof(View.HouseHoldPage));
            Routing.RegisterRoute("AllSupplierPage", typeof(View.AllSupplierPage));
            Routing.RegisterRoute("NewAccountPage", typeof(View.NewAccountPage));
            Routing.RegisterRoute("AllAccountPage", typeof(View.AllAccountPage));
            Routing.RegisterRoute("FirstTransactionPage", typeof(View.FirstTransactionPage)); 
            




        }
        private async void OnMenuClicked(object sender, EventArgs e)
        {
            var page = (sender as MenuFlyoutItem).CommandParameter.ToString();

            await Shell.Current.GoToAsync(page);
        }
    }
}
