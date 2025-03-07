using MAUI_UnitConverter.ViewModels;

namespace MAUI_UnitConverter.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		BindingContext = new ConverterViewModel();
	}
}