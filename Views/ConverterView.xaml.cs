using MAUI_UnitConverter.ViewModels;

namespace MAUI_UnitConverter.Views;

public partial class ConverterView : ContentPage
{
	public ConverterView()
	{
		InitializeComponent();
		BindingContext = new ConverterViewModel();
	}

    private void Picker_SelectedValueChanged(object sender, EventArgs e)
    {
		var context = (ConverterViewModel)BindingContext;
		context.Convert();
    }
}