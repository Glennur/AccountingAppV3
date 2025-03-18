using AccountingAppV3.Models;
using AccountingAppV3.ViewModels;

namespace AccountingAppV3.View;

public partial class NewMemberPage : ContentPage
{

    public Models.Member Member { get; set; }
	public NewMemberPage()
	{
        BindingContext = new ViewModels.NewMemberPageViewModel();
        InitializeComponent();
	}
    public NewMemberPage(Models.Member member)
    {
        BindingContext = new ViewModels.NewMemberPageViewModel();
        InitializeComponent();
    }

    private async void OnClickedCreateNewMember(object sender, EventArgs e)
    {
        var viewModel = (NewMemberPageViewModel)BindingContext;
        await viewModel.CreateNewMemberAsync();        
    }
}

