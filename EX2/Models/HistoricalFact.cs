namespace EX2.Models
{
    public class HistoricalFact
    {
        public string? Fact { get; set; }
        public string? Subjects { get; set; }
        public string? Object { get; set; }
        public string? RelationType { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string? Location { get; set; }
        public string? Note { get; set; }
    }
}