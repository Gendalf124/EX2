// TimelinePage.xaml.cs

using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace EX2
{
    // Обязательно убедитесь, что имя класса совпадает с x:Class в XAML
    public partial class TimelinePage : ContentPage
    {
        public TimelinePage()
        {
            // Этот метод привязывает код к XAML-разметке. 
            // Он генерируется автоматически, если XAML-файл создан правильно.
            InitializeComponent();

            // 1. Создание списка событий
            var events = new ObservableCollection<TimelineEvent>
            {
                new TimelineEvent {
                    Year = "1759",
                    Title = "Начало строительства",
                    Description = "Основание Белорецкого железоделательного завода. Ключевая дата в истории уральской металлургии."
                },
                new TimelineEvent {
                    Year = "1762",
                    Title = "Запуск производства",
                    Description = "Белорецкий завод выпустил первую партию чугуна и железа, ознаменовав начало промышленной деятельности."
                },
                new TimelineEvent {
                    Year = "1880",
                    Title = "Строительство узкоколейки",
                    Description = "Для транспортировки руды и продукции к заводам проложена узкоколейная железная дорога."
                },
                new TimelineEvent {
                    Year = "1923",
                    Title = "Национализация",
                    Description = "После революции завод перешел в государственную собственность СССР и был модернизирован."
                },
                new TimelineEvent {
                    Year = "2024",
                    Title = "Цифровой проект",
                    Description = "Начало работ по историографическому и оцифрованному описанию металлургических заводов района."
                }
            };

            // 2. Привязка списка к элементу CollectionView
            // TimelineCollectionView - это имя, заданное в XAML с помощью x:Name
            TimelineCollectionView.ItemsSource = events;
        }
    }

    // Модель данных для события
    public class TimelineEvent
    {
        // Используем 'required', чтобы решить ошибку "не допускает значение NULL"
        public required string Year { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}