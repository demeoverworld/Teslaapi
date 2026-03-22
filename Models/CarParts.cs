namespace TST_API.Models
{
    public class CarParts
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int Stock { get; set; }
        public string url { get; set; }
        public int year { get; set; }
        public string Model { get; set; } = string.Empty;
    }
}
