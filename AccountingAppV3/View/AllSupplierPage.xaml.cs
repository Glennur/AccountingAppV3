namespace AccountingAppV3.View;

public partial class AllSupplierPage : ContentPage
{
	public AllSupplierPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.AllSupplierPageViewModel();

    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Models.Supplier supplier)
        {            
            await Navigation.PushAsync(new NewSupplierPage(supplier));
        }
    }
}