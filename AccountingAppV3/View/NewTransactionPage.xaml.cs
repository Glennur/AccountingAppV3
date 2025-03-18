using AccountingAppV3.ViewModels;

namespace AccountingAppV3.View;

public partial class NewTransactionPage : ContentPage
{
    private readonly NewTransactionPageViewModel _viewModel;
	public NewTransactionPage()
	{
        _viewModel = new ViewModels.NewTransactionPageViewModel();
        BindingContext = _viewModel;
        InitializeComponent();        
    }

    private async void OnClickedCreateNewTransaction(object sender, EventArgs e)
    {
        var viewModel = (NewTransactionPageViewModel)BindingContext;
        await viewModel.CreateNewTransactionAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        bool yearExists = await _viewModel.CheckIfYearExistsAsync();

        if (!yearExists)
        {
            await Navigation.PushAsync(new FirstTransactionPage());
        }
    }
}

