using EX2.Models;

namespace EX2.Services
{
    public class GraphDataService
    {
        public List<GraphNode> GetGraphNodes()
        {
            return new List<GraphNode>
            {
                new GraphNode {
                    Id = "1",
                    Label = "Белорецкий завод",
                    Type = "factory",
                    Color = "#7C3AED",
                    Size = 60,
                    Icon = "🏭"
                },
                new GraphNode {
                    Id = "2",
                    Label = "Демидовы",
                    Type = "founder",
                    Color = "#DC2626",
                    Size = 50,
                    Icon = "👑"
                },
                new GraphNode {
                    Id = "3",
                    Label = "Твердышевы",
                    Type = "owner",
                    Color = "#059669",
                    Size = 45,
                    Icon = "💰"
                },
                new GraphNode {
                    Id = "4",
                    Label = "Ярцевы",
                    Type = "manager",
                    Color = "#3B82F6",
                    Size = 40,
                    Icon = "👨‍💼"
                }
            };
        }

        public List<HistoricalFact> GetHistoricalFacts()
        {
            return new List<HistoricalFact>
            {
                new HistoricalFact {
                    Fact = "Основание Белорецкого завода",
                    Subjects = "Демидовы",
                    Object = "Белорецкий завод",
                    RelationType = "основатель",
                    StartYear = 1762,
                    EndYear = 1762,
                    Location = "Белорецк",
                    Note = "Первый металлургический завод в районе"
                },
                new HistoricalFact {
                    Fact = "Расширение производства",
                    Subjects = "Твердышевы",
                    Object = "Белорецкий завод",
                    RelationType = "владелец",
                    StartYear = 1800,
                    EndYear = 1850,
                    Location = "Белорецк",
                    Note = "Период активного развития"
                }
            };
        }
    }
}