namespace EX2.Models
{
    public class GraphNode
    {
        public string? Id { get; set; }
        public string? Label { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public int Size { get; set; } = 50;
        public string? Icon { get; set; }
        public Point Position { get; set; }
    }
}