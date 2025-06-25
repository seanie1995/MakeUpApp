namespace MakeUpApp.Models.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {      
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime OpenDate { get; set; }
        public required int PAO { get; set; }
        public required int ProductTypeId { get; set; }
    }
}
