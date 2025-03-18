using AccountingAppV3.Models;
using AccountingAppV3.ViewModels;

namespace AccountingAppV3.View;

public partial class NewSupplierPage : ContentPage
{    
    public Models.Supplier Supplier { get; set; }
    public NewSupplierPage(Models.Supplier supplier) //Tar emot en supplier f�r att uppdatera
	{
        Supplier = supplier;
		BindingContext = new ViewModels.NewSupplierPageViewModel();
		InitializeComponent();
        FillFields();
	}
    public NewSupplierPage() //Tar inte emot n�gon supplier och skapar en ny ist�llet
    {
        BindingContext = new ViewModels.NewSupplierPageViewModel();
        InitializeComponent();
    }

    private async void OnClickedCreateNewSupplier(object sender, EventArgs e)
    {
        if (BindingContext is ViewModels.NewSupplierPageViewModel viewModel)
        {
            if (Supplier == null)
            {
                Supplier = new Models.Supplier()
                {
                    SupplierName = CompanyName.Text,
                    SupplierAccountNumber = AccountNr.Text,
                    Description = Description.Text
                    
                };
                await viewModel.SaveSupplierAsync(Supplier);
                UpdateMessage.Text = $"{CompanyName.Text} �r tillagd";
                
            }
            else
            {                
                {
                    Supplier.SupplierName = CompanyName.Text;
                    Supplier.SupplierAccountNumber = AccountNr.Text;
                    Supplier.Description = Description.Text;
                    
                };
                await viewModel.UpdateSupplierAsync(Supplier);
                UpdateMessage.Text = $"{CompanyName.Text} �r uppdaterad";

            }

        }        
        ClearFields();
    }
    private void FillFields()
    {
        if(Supplier != null)
        {            
            CompanyName.Text = Supplier.SupplierName;
            AccountNr.Text = Supplier.SupplierAccountNumber;
            Description.Text = Supplier.Description;
            SaveButton.Text = "Uppdatera leverant�r";
            HeadLiner.Text = "Uppdatera leverant�r";
        }
    }
    private void ClearFields()
    {

        CompanyName.Text = string.Empty;
        AccountNr.Text = string.Empty;
        Description.Text = string.Empty;
        SaveButton.Text = "Skapa leverant�r";
        HeadLiner.Text = "Ny leverant�r";

    }

}