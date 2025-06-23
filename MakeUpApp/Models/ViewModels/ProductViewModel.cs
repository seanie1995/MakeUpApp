namespace MakeUpApp.Models.ViewModels
{
    public class ProductViewModel
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime OpenDate { get; set; }
        public required int PAO { get; set; }
        public required string ProductTypeName { get; set; }
    }
}
