namespace MakeUpApp.Models.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime OpenDate { get; set; }
        public  int PAO { get; set; }
        public  string ProductTypeName { get; set; }
    }
}
