namespace MakeUpApp.Models
{
    public class ProductType
    {
       public int id {  get; set; }
       public required string name { get; set; }
       public ICollection<Product>? products { get; set; } 

    }
}
