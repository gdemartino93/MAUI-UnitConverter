using MAUI_UnitConverter.Views;

namespace MAUI_UnitConverter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuView());
        }
    }
}
