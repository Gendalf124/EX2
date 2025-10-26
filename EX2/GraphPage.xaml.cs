using EX2.Models;
using EX2.Services;
using EX2.ViewModels;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace EX2
{
    public partial class GraphPage : ContentPage
    {
        private readonly GraphViewModel _viewModel;

        public GraphPage()
        {
            InitializeComponent();
            _viewModel = new GraphViewModel(new GraphDataService());
            BindingContext = _viewModel;

            // Подписываемся на события после инициализации компонентов
            if (FactsCollectionView != null)
                FactsCollectionView.SelectionChanged += OnFactSelected;

            if (FilterPicker != null)
                FilterPicker.SelectedIndexChanged += OnFilterChanged;
        }

        private async void OnRefreshClicked(object sender, System.EventArgs e)
        {
            _viewModel.LoadData();
            await DisplayAlert("Обновлено", "Данные графа успешно обновлены", "OK");
        }

        private void OnFilterChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
            if (picker?.SelectedItem is string selectedFilter)
            {
                _viewModel.ApplyFilter(selectedFilter);
            }
        }

        private void OnShowAllClicked(object sender, System.EventArgs e)
        {
            if (FilterPicker == null)
            {
            }
            else
                FilterPicker.SelectedIndex = 0;
            _viewModel.ShowAllConnections();
        }

        private void OnFactSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is HistoricalFact fact)
            {
                _viewModel.SelectFact(fact);
            }
        }

        private void OnNodeTapped(object sender, EventArgs e)
        {
            if (sender is Border border && border.BindingContext is GraphNode node)
            {
                _viewModel.SelectNode(node);
            }
        }

        private async void OnExportClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Экспорт", "Экспорт данных графа в выбранный формат", "OK");
        }

        private async void OnAnalyzeClicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Анализ", "Запуск анализа сетевых связей и выявление паттернов", "OK");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadData();
        }
    }
}