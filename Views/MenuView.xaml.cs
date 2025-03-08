using MAUI_UnitConverter.ViewModels;

namespace MAUI_UnitConverter.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		var element = (Grid)sender;
		string text = ((Label)element.Children.LastOrDefault()).Text;
		var converterView = new ConverterView
		{
			BindingContext = new ConverterViewModel(ConvertToEnglish(text))
		};
		Navigation.PushAsync(converterView);
    }

	private string ConvertToEnglish(string measurementName)
	{
		switch (measurementName)
		{
			case "Digitali":
				return "Information";
			case "Lunghezza":
				return "Length";
			case "Peso":
				return "Mass";
			case "Temperatura":
				return "Temperature";
			case "Energia":
				return "Energy";
			case "Velocità":
				return "Speed";
			case "Tempo":
				return "Duration";
			default:
				return measurementName;
		}
	}
}