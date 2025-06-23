namespace MakeUpApp.Models
{
    public class ProductType
    {
       public int Id {  get; set; }
       public required string Name { get; set; }
       public ICollection<Product>? Products { get; set; } 

    }
}
