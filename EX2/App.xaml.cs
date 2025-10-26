using Microsoft.Maui.Controls;

namespace EX2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new MainPage()))
            {
                Title = "Горнозаводские корни Белорецка",
                MinimumWidth = 400,
                MinimumHeight = 700
            };
        }
    }
}