using EX2.Models;
using EX2.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EX2.ViewModels
{
    public class GraphViewModel : INotifyPropertyChanged
    {
        private readonly GraphDataService _dataService;
        private ObservableCollection<GraphNode> _graphNodes;
        private ObservableCollection<HistoricalFact> _historicalFacts;
        private ObservableCollection<string> _filterOptions;
        private ObservableCollection<string> _timePeriods;
        private int _nodesCount;
        private int _linksCount;
        private int _factsCount;
        private string? _selectedNodeInfo;

        public GraphViewModel(GraphDataService dataService)
        {
            _dataService = dataService;
            _graphNodes = new ObservableCollection<GraphNode>();
            _historicalFacts = new ObservableCollection<HistoricalFact>();
            _filterOptions = new ObservableCollection<string> { "Все связи", "Только владельцы", "Только управляющие", "Только основатели" };
            _timePeriods = new ObservableCollection<string> { "Весь период", "XVIII век", "XIX век", "XX век" };
            _selectedNodeInfo = "Выберите элемент для просмотра";
            LoadData();
        }

        public ObservableCollection<GraphNode> GraphNodes
        {
            get => _graphNodes;
            set => SetProperty(ref _graphNodes, value);
        }

        public ObservableCollection<HistoricalFact> HistoricalFacts
        {
            get => _historicalFacts;
            set => SetProperty(ref _historicalFacts, value);
        }

        public ObservableCollection<string> FilterOptions => _filterOptions;
        public ObservableCollection<string> TimePeriods => _timePeriods;

        public int NodesCount
        {
            get => _nodesCount;
            set => SetProperty(ref _nodesCount, value);
        }

        public int LinksCount
        {
            get => _linksCount;
            set => SetProperty(ref _linksCount, value);
        }

        public int FactsCount
        {
            get => _factsCount;
            set => SetProperty(ref _factsCount, value);
        }

        public string? SelectedNodeInfo
        {
            get => _selectedNodeInfo;
            set => SetProperty(ref _selectedNodeInfo, value);
        }

        public void LoadData()
        {
            var nodes = _dataService.GetGraphNodes();
            var facts = _dataService.GetHistoricalFacts();

            GraphNodes = new ObservableCollection<GraphNode>(nodes);
            HistoricalFacts = new ObservableCollection<HistoricalFact>(facts);

            NodesCount = GraphNodes.Count;
            FactsCount = HistoricalFacts.Count;
            LinksCount = facts.Count;
        }

        public void ApplyFilter(string? filter)
        {
            if (filter == null) return;

            var allFacts = _dataService.GetHistoricalFacts();
            if (filter == "Все связи")
            {
                HistoricalFacts = new ObservableCollection<HistoricalFact>(allFacts);
            }
            else
            {
                var filtered = allFacts.Where(f => f.RelationType?.Contains(filter) == true).ToList();
                HistoricalFacts = new ObservableCollection<HistoricalFact>(filtered);
            }
            FactsCount = HistoricalFacts.Count;
        }

        public void ShowAllConnections()
        {
            LoadData();
        }

        public void SelectFact(HistoricalFact? fact)
        {
            if (fact == null) return;
            SelectedNodeInfo = $"Выбран факт: {fact.Fact}";
        }

        public void SelectNode(GraphNode? node)
        {
            if (node == null) return;

            SelectedNodeInfo = $"Выбран: {node.Label}";
            var relatedFacts = _dataService.GetHistoricalFacts()
                .Where(f => f.Subjects?.Contains(node.Label ?? "") == true || f.Object == node.Label)
                .ToList();
            HistoricalFacts = new ObservableCollection<HistoricalFact>(relatedFacts);
            FactsCount = HistoricalFacts.Count;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}