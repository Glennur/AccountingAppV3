namespace AccountingAppV3
{
    public partial class MainPage : ContentPage
    {       
        public MainPage()
        {
            BindingContext = new ViewModels.MainPageViewModel();
            InitializeComponent();
        }

       private async void NewTransaction(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.NewTransactionPage());
        }
    }

}
