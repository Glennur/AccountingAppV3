using AccountingAppV3.View;

namespace AccountingAppV3
{
    //public partial class AppShell : Shell
    //{
    //    private static NewTransactionPage _newTransactionPage;
    //    public AppShell()
    //    {
    //        InitializeComponent();
    //        BindingContext = this;

    //        Routing.RegisterRoute("NewTransactionPage", typeof(NewTransactionPage));
    //        Routing.RegisterRoute("TransactionHistoryPage", typeof(TransactionHistoryPage));
    //        Routing.RegisterRoute("NewMemberPage", typeof(NewMemberPage));
    //        Routing.RegisterRoute("NewSupplierPage", typeof(NewSupplierPage));
    //        Routing.RegisterRoute("HouseHoldPage", typeof(HouseHoldPage));
    //        Routing.RegisterRoute("AllSupplierPage", typeof(AllSupplierPage));
    //        Routing.RegisterRoute("NewAccountPage", typeof(NewAccountPage));
    //        Routing.RegisterRoute("AllAccountPage", typeof(AllAccountPage));
    //        Routing.RegisterRoute("FirstTransactionPage", typeof(FirstTransactionPage)); 





    //    }
    //    private async void OnMenuClicked(object sender, EventArgs e)
    //    {
    //        var page = (sender as MenuFlyoutItem).CommandParameter.ToString();

    //        if (page == "NewTransactionPage")
    //        {
    //            if (_newTransactionPage == null)
    //            {
    //                _newTransactionPage = new NewTransactionPage();
    //            }
    //            if (Shell.Current.Navigation.NavigationStack.Contains(_newTransactionPage))
    //            {
    //                await Shell.Current.Navigation.PushAsync(_newTransactionPage);

    //            }
    //            //await Shell.Current.GoToAsync(nameof(NewTransactionPage));
    //            else
    //            {
    //                await Shell.Current.GoToAsync(nameof(NewTransactionPage));

    //            }

    //        }
    //        else
    //        {
    //            await Shell.Current.GoToAsync(page);
    //        }
    //    }
    //}
    public partial class AppShell : Shell
    {
        private static NewTransactionPage _newTransactionPage;

        public AppShell()
        {
            InitializeComponent();
            BindingContext = this;

            Routing.RegisterRoute("NewTransactionPage", typeof(NewTransactionPage));
            Routing.RegisterRoute("TransactionHistoryPage", typeof(TransactionHistoryPage));
            Routing.RegisterRoute("NewMemberPage", typeof(NewMemberPage));
            Routing.RegisterRoute("NewSupplierPage", typeof(NewSupplierPage));
            Routing.RegisterRoute("HouseHoldPage", typeof(HouseHoldPage));
            Routing.RegisterRoute("AllSupplierPage", typeof(AllSupplierPage));
            Routing.RegisterRoute("NewAccountPage", typeof(NewAccountPage));
            Routing.RegisterRoute("AllAccountPage", typeof(AllAccountPage));
            Routing.RegisterRoute("FirstTransactionPage", typeof(FirstTransactionPage));
        }

        private async void OnMenuClicked(object sender, EventArgs e)
        {
            var page = (sender as MenuFlyoutItem).CommandParameter.ToString();

            await Shell.Current.GoToAsync(page);
            //if (page == "NewTransactionPage")
            //{
            //    if (_newTransactionPage == null)
            //    {
            //        _newTransactionPage = new NewTransactionPage();
            //    }
            //    if (Shell.Current.Navigation.NavigationStack.Contains(_newTransactionPage))
            //    {
            //        await Shell.Current.GoToAsync(page);
            //    }
            //    else
            //    {
            //        await Shell.Current.Navigation.PushAsync(_newTransactionPage);
            //    }
            //}
            //else
            //{
            //    await Shell.Current.GoToAsync(page);
            //}
        }
    }
}
