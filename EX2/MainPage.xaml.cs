using Microsoft.Maui.Controls;

namespace EX2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnFactoriesClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Заводы", "Переход к списку металлургических предприятий", "OK");
        }

        private async void OnPersonsClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Персоналии", "Переход к владельцам и управляющим", "OK");
        }

        private async void OnGraphClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GraphPage());
        }

        private async void OnTimelineClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Хронология", "Переход к историческим периодам", "OK");
        }

        private async void OnGalleryClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Галерея", "Переход к архивным материалам", "OK");
        }

        private async void OnAIClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("ИИ-визуализация", "Переход к нейросетевым образам", "OK");
        }

    }
}