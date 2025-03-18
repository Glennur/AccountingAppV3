using AccountingAppV3.ViewModels;

namespace AccountingAppV3.View;

public partial class FirstTransactionPage : ContentPage
{

    public FirstTransactionPage()
    {
        BindingContext = new ViewModels.FirstTransactionPageViewModel();
        InitializeComponent();
    }

    private async void OnClickedCreateFirstTransaction(object sender, EventArgs e)
    {
        var viewModel = (FirstTransactionPageViewModel)BindingContext;
        await viewModel.CreateFirstTransactionAsync();
    }
}