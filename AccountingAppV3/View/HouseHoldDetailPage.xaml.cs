namespace AccountingAppV3.View;

public partial class HouseHoldDetailPage : ContentPage
{
	public HouseHoldDetailPage(Models.HouseHold houseHold, List<Models.Member> members)
	{
        BindingContext = new ViewModels.HouseHoldDetailViewModel(houseHold, members);
        InitializeComponent();
	}
}