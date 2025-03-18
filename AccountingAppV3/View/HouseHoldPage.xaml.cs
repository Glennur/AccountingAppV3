using AccountingAppV3.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AccountingAppV3.View;

public partial class HouseHoldPage : ContentPage
{
	public HouseHoldPage()
	{
        BindingContext = new ViewModels.HouseHoldPageViewModel();
        InitializeComponent();
		
	}
    
    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var houseHold = ((ListView)sender).SelectedItem as Models.HouseHold;
		if(houseHold != null)
		{
			using (var db = new BokforingContext())
			{
				var member = await db.Members.Where(m => m.HouseHoldId == houseHold.Id).ToListAsync();
				var page = new HouseHoldDetailPage(houseHold, member);
				await Navigation.PushAsync(page);
			}
		}
    }
	
}