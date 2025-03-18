namespace AccountingAppV3.View;

public partial class AllAccountPage : ContentPage
{
	public AllAccountPage()
	{
		BindingContext = new ViewModels.AllAccountPageViewModel();
		InitializeComponent();
	}

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var account = ((ListView)sender).SelectedItem as Models.Account;
		if (account != null)
		{
			var page = new AccountDetailPage();
			page.BindingContext = account;
			await Navigation.PushAsync(page);


		}
    }
}