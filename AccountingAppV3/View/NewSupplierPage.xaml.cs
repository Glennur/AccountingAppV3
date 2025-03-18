using AccountingAppV3.Models;
using AccountingAppV3.ViewModels;

namespace AccountingAppV3.View;

public partial class NewSupplierPage : ContentPage
{    
    public Models.Supplier Supplier { get; set; }
    public NewSupplierPage(Models.Supplier supplier) //Tar emot en supplier för att uppdatera
	{
        Supplier = supplier;
		BindingContext = new ViewModels.NewSupplierPageViewModel();
		InitializeComponent();
        FillFields();
	}
    public NewSupplierPage() //Tar inte emot någon supplier och skapar en ny istället
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
                UpdateMessage.Text = $"{CompanyName.Text} är tillagd";
                
            }
            else
            {                
                {
                    Supplier.SupplierName = CompanyName.Text;
                    Supplier.SupplierAccountNumber = AccountNr.Text;
                    Supplier.Description = Description.Text;
                    
                };
                await viewModel.UpdateSupplierAsync(Supplier);
                UpdateMessage.Text = $"{CompanyName.Text} är uppdaterad";

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
            SaveButton.Text = "Uppdatera leverantör";
            HeadLiner.Text = "Uppdatera leverantör";
        }
    }
    private void ClearFields()
    {

        CompanyName.Text = string.Empty;
        AccountNr.Text = string.Empty;
        Description.Text = string.Empty;
        SaveButton.Text = "Skapa leverantör";
        HeadLiner.Text = "Ny leverantör";

    }

}