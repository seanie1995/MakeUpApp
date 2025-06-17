using MakeUpApp.Models;

namespace MakeUpApp.Data.Repos.IRepos
{
    public interface IProductRepo
    {
        Task<bool> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<IEnumerable<Product>> GetUserProductsAsync(int id);
        Task<bool> UpdateProductAsync(Product existingProduct, Product updatedProduct);
        Task<bool> DeleteProductAsync(Product product);
            
    }
}
