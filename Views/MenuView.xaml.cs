using MAUI_UnitConverter.ViewModels;

namespace MAUI_UnitConverter.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}
}