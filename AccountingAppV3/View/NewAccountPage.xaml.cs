using AccountingAppV3.Models;


namespace AccountingAppV3.View;

public partial class NewAccountPage : ContentPage
{
	public Models.Account Account { get; set; }
	public NewAccountPage(Models.Account account)
	{
		BindingContext = new ViewModels.NewAccountPageViewModel();
        Account = account;
        InitializeComponent();
        FillFields();
	}
    public NewAccountPage()
    {
        BindingContext = new ViewModels.NewAccountPageViewModel();
        InitializeComponent();
    }

    private async void OnClickedCreateNewAccount(object sender, EventArgs e)
    {
        if(BindingContext is ViewModels.NewAccountPageViewModel viewModel)
        {
            
            bool testAccountNr = int.TryParse(AccountNr.Text, out int result);

            if(Account == null && testAccountNr)
            {
                Account = new Models.Account()
                {

                    AccountNumber = result,
                    AccountName = AccountName.Text,
                    Balance = 0,
                    AccountDescription = AccountDescription.Text
                };
                await viewModel.SaveAccountAsync(Account);
                UpdateMessage.Text = $"{AccountName.Text} är tillagd";

            }
            if(!testAccountNr)
            {
                AccountNr.Text = "Felaktig data";
                AccountNr.BackgroundColor = Colors.Red;
            }
            ClearFields();
        }
        

    }
    private void FillFields()
    {
        if (Account != null)
        {
            AccountName.Text = Account.AccountName;
            AccountNr.Text = Account.AccountNumber.ToString();
            AccountDescription.Text = Account.AccountDescription;
            SaveButton.Text = "Uppdatera konto";
            HeadLiner.Text = "Uppdatera konto";
        }
    }
    private void ClearFields()
    {

        AccountNr.Text = string.Empty;
        AccountName.Text = string.Empty;
        AccountDescription.Text = string.Empty;
        SaveButton.Text = "Skapa konto";
        HeadLiner.Text = "Nytt konto";
        Account = null;

    }

    private void AccountNrTextChaged(object sender, TextChangedEventArgs e)
    {
        AccountNr.BackgroundColor = null;
    }
}
